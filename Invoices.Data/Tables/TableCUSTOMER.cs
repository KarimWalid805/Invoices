
using Invoices.Data.Records;
using Lib.Data.Records;
using System.Data;


namespace Invoices.Data.Tables
{
    public class TableCUSTOMER : CDBTable<CUSTOMER>
    {
        public TableCUSTOMER() : base("Customer")
        {
        }
        // --------------------------------------------------------------------------------------
        public override void LoadTable(IDbTransaction? p_iTransaction)
        {
            var oRecords = this.DB.Select<CUSTOMER>("select * from CUSTOMER", p_iTransaction);
            this.records.Clear();
            if (oRecords != null)
                this.records = oRecords;
        }
        // --------------------------------------------------------------------------------------
        public override void SaveTable(IDbTransaction? p_iTransaction)
        {
            if (this.records != null)
            {
             
                this.DB.SaveChanges<CUSTOMER>(this.records,

                            // Provide the insert statement that will be used for new records
                            @"
                                                    insert into CUSTOMER
                        (CUSTOMER_CATEGORY_CID, CUST_NAME)
                        values 
                        (@CUSTOMER_CATEGORY_CID, @CUST_NAME)",

                            // Provide the update statement that will be used for updated records
                            @"
                             update CUSTOMER set 
                            CUSTOMER_CATEGORY_CID = @CUSTOMER_CATEGORY_CID,
                             CUST_NAME = @CUST_NAME
                            where 
                            ID = @ID
                                ",

                            // Provide the delete statement that will be used for deleted records
                            "delete from CUSTOMER where ID = @ID",

                            p_iTransaction
                        );

                this.LoadTable(p_iTransaction);
            }
        }
    }
}
