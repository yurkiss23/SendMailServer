namespace WebServSendMail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablewssm_sendMail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WSSM_SendMail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderEmail = c.String(nullable: false, maxLength: 255),
                        SenderName = c.String(nullable: false, maxLength: 255),
                        ReceiverEmail = c.String(nullable: false, maxLength: 255),
                        Title = c.String(nullable: false, maxLength: 255),
                        Body = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WSSM_SendMail");
        }
    }
}
