namespace Flix.UX.Views
{
    partial class CViewBrowserGenre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CViewBrowserGenre));
            lstGenres = new ListView();
            imlGenre = new ImageList(components);
            SuspendLayout();
            // 
            // lstGenres
            // 
            lstGenres.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstGenres.Location = new Point(12, 12);
            lstGenres.Name = "lstGenres";
            lstGenres.Size = new Size(776, 426);
            lstGenres.TabIndex = 0;
            lstGenres.UseCompatibleStateImageBehavior = false;
            lstGenres.Click += DoOnAnyCommand;
            lstGenres.DoubleClick += DoOnAnyCommand;
            // 
            // imlGenre
            // 
            imlGenre.ColorDepth = ColorDepth.Depth32Bit;
            imlGenre.ImageStream = (ImageListStreamer)resources.GetObject("imlGenre.ImageStream");
            imlGenre.TransparentColor = Color.Transparent;
            imlGenre.Images.SetKeyName(0, "005-gas mask.png");
            imlGenre.Images.SetKeyName(1, "050-saturn.png");
            imlGenre.Images.SetKeyName(2, "019-lab.png");
            imlGenre.Images.SetKeyName(3, "004-black hole.png");
            imlGenre.Images.SetKeyName(4, "010-backpack.png");
            imlGenre.Images.SetKeyName(5, "006-astronaut.png");
            imlGenre.Images.SetKeyName(6, "038-alien.png");
            imlGenre.Images.SetKeyName(7, "031-robot.png");
            imlGenre.Images.SetKeyName(8, "030-parasite.png");
            // 
            // CViewBrowserGenre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstGenres);
            Name = "CViewBrowserGenre";
            Text = "CViewBrowserGenre";
            ResumeLayout(false);
        }

        #endregion

        private ListView lstGenres;
        private ImageList imlGenre;
    }
}