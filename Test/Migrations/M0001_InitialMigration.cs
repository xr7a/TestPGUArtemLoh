using FluentMigrator;
using FluentMigrator.Expressions;

namespace Test.Migrations;
[Migration(1)]
public class M0001_InitialMigration: Migration 
{
    public override void Up()
    {
        Create.Table("Cars")
            .WithColumn("id").AsInt64().PrimaryKey().NotNullable()
            .WithColumn("brand").AsString()
            .WithColumn("model").AsString()
            .WithColumn("yearofrelease").AsInt64()
            .WithColumn("vincode").AsString();
        Insert.IntoTable("Cars")
            .Row(new {id = 1,  brand = "sdfs", model = "dsfsd", yearofrelease = 2012, vincode = "dsflskdf"});
        Create.Table("Users")
            .WithColumn("Id").AsInt64().PrimaryKey().NotNullable()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Address").AsString()
            .WithColumn("PhoneNumber").AsString();
        Create.Table("Orders")
            .WithColumn("Id").AsInt64().PrimaryKey().NotNullable()
            .WithColumn("UserId").AsInt64().NotNullable()
            .WithColumn("CarId").AsInt64().NotNullable()
            .WithColumn("DateStart").AsDateTime()
            .WithColumn("Description").AsString()
            .WithColumn("Status").AsString().NotNullable();
        Create.ForeignKey().FromTable("Orders").ForeignColumn("UserId").ToTable("Users").PrimaryColumn("Id");
        Create.ForeignKey().FromTable("Orders").ForeignColumn("CarId").ToTable("Cars").PrimaryColumn("id");
    }

    public override void Down()
    {
        Delete.Table("Cars");
        Delete.Table("Users");
        Delete.Table("Orders");
    }
}