namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes SET Name = 'Noleggio singolo' WHERE Id = 1");
            Sql("UPDATE MemberShipTypes SET Name = 'Mensile' WHERE Id = 2");
            Sql("UPDATE MemberShipTypes SET Name = 'Trimestrale' WHERE Id = 3");
            Sql("UPDATE MemberShipTypes SET Name = 'Annuale' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
