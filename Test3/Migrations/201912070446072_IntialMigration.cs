namespace Test3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        PassWord = c.String(nullable: false, maxLength: 20),
                        Account_AccountID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountID)
                .Index(t => t.Account_AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Account_AccountID", "dbo.Accounts");
            DropIndex("dbo.Users", new[] { "Account_AccountID" });
            DropTable("dbo.Users");
            DropTable("dbo.Accounts");
        }
    }
}
