using lesson13;
using System.ComponentModel;

var service = new AutoService();
service.Name = "Levandivka Auto Parts";
service.Id = 1;

var vehicle=new Vehicle();
vehicle.Name = "Ford";
vehicle.Id = 2;
vehicle.AutoServiceId = 1;

var engine = new Engine();
engine.Name = "LS1";
engine.Id = 3;
engine.HorsePower = 280;
engine.VehicleId = 2;

var suspention =  new Suspention();
suspention.Name = "Bilstein";
suspention.Id = 5;
suspention.VehicleId = 2;
suspention.Type = SuspentionParts.Coilover;

var wheel = new Wheel();
wheel.Name = "BBS";
wheel.Id = 6;
wheel.Radius = 18;
wheel.VehicleId = 2;
vehicle.Wheels = new List<Wheel>
{
    wheel
};
vehicle.Engine= engine;
vehicle.Suspentions=new List<Suspention> { suspention };
service.Vehicls=new List<Vehicle> { vehicle };
