using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShopWeb.Products.Migrations
{
    public partial class ProductsSeed : Migration
    {
        protected override void Up(MigrationBuilder mB)
        {
            //camisas
            mB.Sql($"INSERT INTO product(pk_id,name,description,price,Stock,fk_category_id,image_url)" +
                $"VALUES('{Guid.NewGuid()}','Camisetas estampa lisa'," +
                $"'Tamanhos P-M-G-GG', 89.99,500,'c05034fa-f25f-46a1-9388-d21c0935b8d0','https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcTz7-2FyzdXUqIgHYw_2KNCHVRqgFrSlmAIEGmCY41NqHT3X6aepYfUVL56DF5qwa4HBs21WXF9tuS4wS5l44SSvS2D62UB3YHb4qtArgtVJGSfPi-l72NJEA&usqp=CAE')");
            mB.Sql($"INSERT INTO product(pk_id,name,description,price,Stock,fk_category_id,image_url)" +
                $"VALUES('{Guid.NewGuid()}','Camisetas banda U2'," +
                $"'Tamanhos P-M-G-GG', 109.99,100,'c05034fa-f25f-46a1-9388-d21c0935b8d0','https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcQ1Ly-vi86jvN2gq8L_uLp4bVoI9UsD_DvhG4n4P-nSdDqk7qCXMm1_fdl_-tv1g7tLPRCUGn5obEEc4sXIVPmTFGwuQ6--JA16gEetPmPrskMnwnDYaApYaQ&usqp=CAE')");

            //tênis
            mB.Sql($"INSERT INTO product(pk_id,name,description,price,Stock,fk_category_id,image_url)" +
                $"VALUES('{Guid.NewGuid()}','Nike React Miler 2'," +
                $"'Tamanhos 40 até 46', 509.99,400,'6b982c2a-99b2-4faa-9492-70f79d0106d9','https://m.media-amazon.com/images/I/317kGmNdTvL._AC_SY1000_.jpg')");
            mB.Sql($"INSERT INTO product(pk_id,name,description,price,Stock,fk_category_id,image_url)" +
                $"VALUES('{Guid.NewGuid()}','Adidas Court Block'," +
                $"'Tamanhos 40 até 46 masculino e feminino', 179.99,400,'6b982c2a-99b2-4faa-9492-70f79d0106d9','https://static.netshoes.com.br/produtos/tenis-adidas-courtblock/40/FB9-3749-440/FB9-3749-440_zoom1.jpg?ts=1720809534&ims=1088x')");

            //vegetais
            mB.Sql($"INSERT INTO product(pk_id,name,description,price,Stock,fk_category_id,image_url)" +
                $"VALUES('{Guid.NewGuid()}','Cenoura'," +
                $"'1 quilo', 4.99,400,'8549e7ae-1fe3-4fd7-b62f-dcea08829afe','https://www.infoescola.com/wp-content/uploads/2010/08/cenoura_250834906.jpg')");
        }

        protected override void Down(MigrationBuilder mB)
        {
            mB.Sql("REMOVE FROM product");
        }
    }
}
