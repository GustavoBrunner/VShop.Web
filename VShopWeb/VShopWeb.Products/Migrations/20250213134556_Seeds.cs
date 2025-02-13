using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShopWeb.Products.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder mB)
        {
            //categories seed
            mB.Sql($"INSERT INTO category(pk_id,name,description)" +
                $"VALUES('{Guid.NewGuid()}','Camisetas','Camisetas informais de todos os tipos')");
            mB.Sql($"INSERT INTO category(pk_id,name,description) " +
                $"VALUES('{Guid.NewGuid()}','Vegetais','Vegetais orgânicos')");
            mB.Sql($"INSERT INTO category(pk_id,name,description) " +
                $"VALUES('{Guid.NewGuid()}','Tênis','Diferente tipos de tênis para todas as ocasiões')");
        
        }

        protected override void Down(MigrationBuilder mB)
        {
            mB.Sql("DELETE FROM category");
        }
    }
}
