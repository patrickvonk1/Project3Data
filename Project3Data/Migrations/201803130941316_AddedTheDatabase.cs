namespace Project3Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTheDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BicycleTheftModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        Location = c.String(),
                        City = c.String(),
                        Neighbourhood = c.String(),
                        Street = c.String(),
                        DayOfTheWeek = c.String(),
                        Keyword = c.String(),
                        Sort = c.String(),
                        Brand = c.String(),
                        Type = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ParkingGarageModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        IsOpen = c.Boolean(nullable: false),
                        ParkingCapacity = c.Int(nullable: false),
                        VacantSpaces = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WeatherModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        DayAverageWindspeed = c.Single(nullable: false),
                        LowestHourAverageWindspeed = c.Single(nullable: false),
                        HourWindspeed = c.Int(nullable: false),
                        DayAverageTemperature = c.Single(nullable: false),
                        MinimumTemperature = c.Single(nullable: false),
                        HourMinimumTemperature = c.Int(nullable: false),
                        MaximumTemperature = c.Single(nullable: false),
                        HourMaximumTemperature = c.Int(nullable: false),
                        RainfallDuration = c.Single(nullable: false),
                        RainfallDaySum = c.Single(nullable: false),
                        RainfallHighestHourSum = c.Single(nullable: false),
                        HourHighestRainfall = c.Int(nullable: false),
                        AverageDayForecast = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeatherModels");
            DropTable("dbo.ParkingGarageModels");
            DropTable("dbo.BicycleTheftModels");
        }
    }
}
