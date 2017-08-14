namespace SalesDB2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalesDateDefaultValue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Sales", "Date", d => d.DateTime(defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("Sales", "Date", d => d.DateTime(defaultValue: null));
        }
    }
}
