using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Invoices.Common
{
    // [PATTERNS] Singleton
    public class CSettings
    {
        // .....................................................................
        /*
        // [.NET] Automatic lazy initialization mechanism with the built-in Lazy class.
        // The constructor of Lazy needs a function, here an anonymous function is created with a lambda expression
        private static Lazy<CSettings> _instanceLazy = new Lazy<CSettings>( () => new CSettings() );

        public static CSettings Instance { get { return _instanceLazy.Value; } }
        */
        // .....................................................................

        private static CSettings? _instance = null;

        public static CSettings Instance
        {
            get
            {
                // [PATTERNS] Lazy initialization
                if (_instance == null)
                    _instance = new CSettings();
                return _instance;
            }
        }
        // .....................................................................

        public string DBServerURL { get; set; }
        public string DBName { get; set; }
        public string DBUser { get; set; }
        public string DBPassword { get; set; }

        private string __settingsFileName;

        // The folllowing is a C# attribute. When you use this attribute this property
        // will be excluded (ignored) from JSON serialization/deserialization
        [JsonIgnore]
        public string FileName { get { return __settingsFileName; } }
        // ........................................................................


        // -------------------------------------------------------------------------------------------
        public CSettings()
        {
            String sSettingsFolder = this.getParentPath(4);

            // [C#] Joining paths using the platform's  path separator
            this.__settingsFileName = Path.Join(sSettingsFolder, "settings.json");

            // Assign the default values for the settings (read the next method to understand what happens with null)
            Assign(null);
        }
        // ------------------------------------------------------------------------------------------------
        public void Assign(CSettings? p_oSettings)
        {
            // [C#] Use the null-coalescing operator ??, to a default value at the right side,
            // when the object/property at the right side is null

            // [C#] The null conditional operator ?, ensures that the code will not stop with an exception,
            // when a nullable field/property/local variable contains null

            this.DBServerURL = p_oSettings?.DBServerURL ?? "mssql-203334-0.cloudclusters.net,10033";
            this.DBName = p_oSettings?.DBName ?? "ERP";
            this.DBUser = p_oSettings?.DBUser ?? "dev";
            this.DBPassword = p_oSettings?.DBPassword ?? "CS412#fall25";
        }
        // -------------------------------------------------------------------------------------------
        // Go back p_nStepsBack folders from the folder from which the executable runs
        private string getParentPath(int p_nStepsBack)
        {
            // [C#] Getting the current executing directory
            string sResult = Environment.CurrentDirectory;
            for (int nPreviousFolder = 1; nPreviousFolder <= p_nStepsBack; nPreviousFolder++)
            {
                var oConfigFolder = Directory.GetParent(sResult);
                if (oConfigFolder != null)
                    sResult = oConfigFolder.FullName;
            }
            return sResult;
        }
        // ------------------------------------------------------------------------------------------------
        public void SaveJSON(object p_oSourceObject)
        {
            // [C#] This is an example of serializing an object into a JSON string
            JsonSerializerOptions oOptions = new JsonSerializerOptions();
            oOptions.WriteIndented = true;

            string sJSON = JsonSerializer.Serialize(p_oSourceObject, oOptions);
            File.WriteAllText(this.FileName, sJSON);
        }
        // --------------------------------------------------------------------------------------
        public void Save()
        {
            this.SaveJSON(this);
        }
        // -------------------------------------------------------------------------------------------
        public CSettings? LoadJSON()
        {
            CSettings? oResult = null;

            if (File.Exists(FileName))
            {
                Debug.WriteLine($"Loading settings from JSON file {this.FileName}.");

                // [C#] This is an example of deserializing a C# object from a JSON String
                string sJSON = File.ReadAllText(this.FileName);
                oResult = (CSettings?)JsonSerializer.Deserialize(sJSON, GetType());
            }
            else
                Debug.WriteLine($"Settings file {this.FileName} is not found.");

            return oResult;
        }
        // --------------------------------------------------------------------------------------
        public void Load()
        {
            if (!File.Exists(FileName))
            {
                // Lazy initialization of settings:
                // If the settings file does not exist, the first run will create the settings file.
                SaveJSON(this);
            }
            else
            {
                // If the file is successfully loaded, it will assign the values of loaded settings
                CSettings? oLoadedSettings = LoadJSON();
                if (oLoadedSettings != null)
                    Assign(oLoadedSettings);
            }
        }
        // --------------------------------------------------------------------------------------
    }
}
