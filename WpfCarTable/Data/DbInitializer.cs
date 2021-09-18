using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCarTable.Services;

namespace WpfCarTable.Data
{
    class DbInitializer
    {
        private readonly EntitiesDBContext _db;
        private readonly ILogger<DbInitializer> _Logger;

        public DbInitializer(EntitiesDBContext db, ILogger<DbInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация БД...");

            //_Logger.LogInformation("Удаление существующей БД...");
            //await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            //_Logger.LogInformation("Удаление существующей БД выполнено за {0} мс", timer.ElapsedMilliseconds);


            _Logger.LogInformation("Миграция БД...");
            await _db.Database.MigrateAsync().ConfigureAwait(false);
            _Logger.LogInformation("Миграция БД выполнена за {0} мс", timer.ElapsedMilliseconds);

            if (await _db.Orders.AnyAsync()) return;

            await InitializeBrandCarAsync();
            await InitializeModelCarAndOrdersAsync();
            //await InitializeOrder();

            _Logger.LogInformation("Инициализация БД выполнена за {0} с", timer.Elapsed.TotalSeconds);
        }

        private const int __brandCarsCount = 5;

        private string[] brands = { "BMW", "Audi", "Mercedes", "Infiniti", "Lexus" };

        private string[] modelBMW = { "BMW 7", "BMW 8", "BMW 5", "BMW X6", "BMW X5" };

        private string[] modelAudi = { "Audi A8", "Audi A4", "Audi A6", "Audi S5", "Audi A3" };

        private string[] modelMercedes = { "Mercedes-Benz CLA AMG", "Mercedes-Benz CLS",
            "Mercedes-Benz S", "Mercedes-Benz A", "Mercedes-Benz C" };

        private string[] modelInfiniti = { "Infiniti Q50", "Infiniti Q60",
            "Infiniti QX60", "Infiniti QX50", "Infiniti QX80" };

        private string[] modelLexus = { "Lexus LC", "Lexus LS", "Lexus ES",
            "Lexus GX", "Lexus LX" };

        private BrandCar[] brandCars;

        private async Task InitializeBrandCarAsync()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация марок автомобилей...");

            brandCars = new BrandCar[__brandCarsCount];
            for (var i = 0; i < __brandCarsCount; i++)
                brandCars[i] = new BrandCar { Name = brands[i] };

            await _db.BrandCars.AddRangeAsync(brandCars);
            await _db.SaveChangesAsync();

            _Logger.LogInformation("Инициализация марок авто выполнена за {0} мс", timer.ElapsedMilliseconds);
        }


        private List<Order> ordersList = new List<Order>();
        private ModelCar modelCar = new ModelCar();
        Random rnd = new();
        private int year;
        private int month;
        private int day;
        private async Task InitializeModelCarAndOrdersAsync()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация всех моделей и заказов...");

            foreach(BrandCar br in brandCars)
            {
                //modelCar.Brand = null;
                //modelCar.Name = null;

                switch (br.Name)
                {
                    case "BMW":
                        _Logger.LogInformation("Инициализация моделей и заказов BMW...");
                        await InitOrdersAndModelsAsync(br, modelBMW);
                        _Logger.LogInformation("Инициализация марок BMW выполнена за {0} мс", timer.ElapsedMilliseconds);
                        //for (var i = 0; i < modelBMW.Length; i++)
                        //{
                        //    modelCar.Brand = br;
                        //    modelCar.Name = modelBMW[1];

                        //    for (int k = 0; k < 100; k++)
                        //    {
                        //        ordersList.Add(new Order
                        //        {
                        //            Model_Car = modelCar,
                        //            Proceeds = rnd.Next(1000000, 6000000),
                        //            Date = new DateTime(rnd.Next(2016,2022),rnd.Next(1,13),rnd.Next(1,31))
                        //        });
                        //    }
                        //    await _db.ModelCars.AddAsync(modelCar);
                        //    await _db.Orders.AddRangeAsync(ordersList);
                        //    ordersList.Clear();
                        //}

                        break;
                    case "Audi":
                        _Logger.LogInformation("Инициализация моделей и заказов Audi...");
                        await InitOrdersAndModelsAsync(br, modelAudi);
                        _Logger.LogInformation("Инициализация марок Audi выполнена за {0} мс", timer.ElapsedMilliseconds);
                        break;
                    case "Mercedes":
                        _Logger.LogInformation("Инициализация моделей и заказов Mercedes...");
                        await InitOrdersAndModelsAsync(br, modelMercedes);
                        _Logger.LogInformation("Инициализация марок Mercedes выполнена за {0} мс", timer.ElapsedMilliseconds);
                        break;
                    case "Infiniti":
                        _Logger.LogInformation("Инициализация моделей и заказов Infiniti...");
                        await InitOrdersAndModelsAsync(br, modelInfiniti);
                        _Logger.LogInformation("Инициализация марок Infiniti выполнена за {0} мс", timer.ElapsedMilliseconds);
                        break;
                    case "Lexus":
                        _Logger.LogInformation("Инициализация моделей и заказов Lexus...");
                        await InitOrdersAndModelsAsync(br, modelLexus);
                        _Logger.LogInformation("Инициализация марок Lexus выполнена за {0} мс", timer.ElapsedMilliseconds);
                        break;
                }
            }
            _Logger.LogInformation("Инициализация моделей авто и заказов" +
                " выполнена за {0} мс", timer.Elapsed.TotalSeconds);
        }

        private async Task InitOrdersAndModelsAsync(BrandCar br, string[] modelArray)
        {
            for (var i = 0; i < modelArray.Length; i++)
            {
                modelCar.Id = new Guid();
                modelCar.Brand = br;
                modelCar.Name = modelArray[i];

                for (int k = 0; k < 100; k++)
                {
                    year = rnd.Next(2016, 2022);
                    month = rnd.Next(1, 13);
                    if(month == 2)
                        day = rnd.Next(1, 29);
                    else day = rnd.Next(1, 31);

                    ordersList.Add(new Order
                    {
                        Model_Car = modelCar,
                        Proceeds = rnd.Next(1000000, 6000000),
                        Date = new DateTime(year, month, day)
                    });
                }
                await _db.ModelCars.AddAsync(modelCar);
                await _db.Orders.AddRangeAsync(ordersList);
                _Logger.LogInformation("********  InitOrdersAndModelsAsync перед сохранением в БД...");
                await _db.SaveChangesAsync();
                modelCar.Brand = null;
                modelCar.Name = null;
                modelCar.Id = Guid.Empty;
                ordersList.Clear();
            }
            _Logger.LogInformation("******** Завершение метода InitOrdersAndModelsAsync...");
        }

    }
}
