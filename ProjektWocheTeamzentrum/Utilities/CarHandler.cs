using ProjektWocheTeamzentrum.Models.Cars;
using ProjektWocheTeamzentrum.Models.Events;
using ProjektWocheTeamzentrum.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektWocheTeamzentrum.Utilities
{
    public static class CarHandler
    {
        public static async Task<List<CarClass>> InitializeCarsAsync()
        {
            List<CarClass> carClasses = new List<CarClass>();
            try
            {
                await GetAllCarClassesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Fahrzeugdaten: {ex.Message} \n\n Lade Standardfahrzeuge...", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                // ===========================
                //        iRACING
                // ===========================

                // --- NEC / TCR 2025 ---
                CarClass IRacing_NEC_TCR_2025 = new CarClass
                {
                    Name = "NEC / TCR 2025",
                    SimulationType = 3,
                    Cars = new List<Car>()
                    {

                    new Car("Audi", "RS3 LMS TCR"),
                    new Car("Hyundai","Elantra N TCR"),
                    new Car("Honda", "Civic Type R TCR")
                    }
                };
                carClasses.Add(IRacing_NEC_TCR_2025);



                // --- GT3 ---
                CarClass IRacing_GT3 = new CarClass
                {
                    Name = "GT3",
                    SimulationType = 3,
                    Cars = new List<Car>()
                    {
                new Car("Acura NSX GT3 Evo 22"),
                new Car("Audi R8 LMS GT3"),
                new Car("Audi R8 LMS Evo II GT3"),
                new Car("BMW M4 GT3 Evo"),
                new Car("BMW Z4 GT3"),
                new Car("Mercedes AMG GT3"),
                new Car("Mercedes AMG GT3 2020"),
                new Car("Ferrari 296 GT3"),
                new Car("Ferrari 488 GT3"),
                new Car("Ferrari 488 GT3 Evo 2020"),
                new Car("Lamborghini Huracán GT3 EVO"),
                new Car("Chevrolet Corvette Z06 GT3.R"),
                new Car("McLaren 720S GT3"),
                new Car("McLaren MP4-12C GT3"),
                new Car("Ford Mustang GT3"),
                new Car("Porsche 911 GT3 R"),
                new Car("Porsche 911 GT3 R (992)"),
                new Car("Aston Martin Vantage GT3")
                    }
                };
                carClasses.Add(IRacing_GT3);

                // --- GT4 ---
                CarClass IRacing_GT4 = new CarClass
                {
                    Name = "GT4",
                    SimulationType = 3,
                    Cars = new List<Car>()
                                    {
                new Car("Aston Martin Vantage GT4"),
                new Car("BMW M4 F82 GT4"),
                new Car("BMW M4 G82 GT4"),
                new Car("Porsche 718 Cayman GT4 Clubsport"),
                new Car("McLaren 570S GT4"),
                new Car("Mercedes-AMG GT4"),
                new Car("Ford Mustang GT4")
                                    }
                };
                carClasses.Add(IRacing_GT4);

                // --- M2 ---
                CarClass IRacing_M2 = new CarClass
                {
                    Name = "M2",
                    SimulationType = 3,
                    Cars = new List<Car>()
                    {
                new Car("BMW M2 CS Racing")
                    }
                };
                carClasses.Add(IRacing_M2);

                // --- LMP2 ---
                CarClass IRacing_LMP2 = new CarClass
                {
                    Name = "LMP2",
                    SimulationType = 3,
                    Cars = new List<Car>()
                    {
                new Car("Dallara P217 LMP2")
                    }
                };
                carClasses.Add(IRacing_LMP2);

                // --- GTP ---
                CarClass IRacing_GTP = new CarClass
                {
                    Name = "GTP",
                    SimulationType = 3,
                    Cars = new List<Car>()
                    {
                new Car("Porsche 963 GTP"),
                new Car("BMW M Hybrid V8"),
                new Car("Cadillac V-Series.R GTP"),
                new Car("Acura ARX-06 GTP"),
                new Car("Ferrari 499P") }
                };
                carClasses.Add(IRacing_GTP);

                // --- Cup ---
                CarClass IRacing_Cup = new CarClass
                {
                    Name = "Cup",
                    SimulationType = 3,
                    Cars = new List<Car>()
                    {
                new Car("Porsche 911 GT3 Cup"),
                new Car("Porsche 911 GT3 Cup (992)")
                    }
                };
                carClasses.Add(IRacing_Cup);


                // ===========================
                //          LMU
                // ===========================

                // --- LMGT3 (GT3) ---
                CarClass LMU_GT3 = new CarClass
                {
                    Name = "LMGT3 (GT3)",
                    SimulationType = 1,
                    Cars = new List<Car>()
                    {
                new Car("Ford Mustang LMGT3"),
                new Car("McLaren 720S LMGT3 Evo"),
                new Car("Mercedes AMG LMGT3 Evo"),
                new Car("BMW M4 LMGT3"),
                new Car("Aston Martin Vantage LMGT3"),
                new Car("Chevrolet Corvette Z06 GT3.R"),
                new Car("Ferrari 296 LMGT3"),
                new Car("Lexus RC F LMGT3"),
                new Car("Porsche 911 GT3 R LMGT3"),
                new Car("Lamborghini Huracán LMGT3 Evo2")
                    }
                };
                carClasses.Add(LMU_GT3);

                // --- LMP2 ---
                CarClass LMU_LMP2 = new CarClass
                {
                    Name = "LMP2",
                    SimulationType = 1,
                    Cars = new List<Car>()
                    {
                new Car("Oreca 07 Gibson")
                    }
                };
                carClasses.Add(LMU_LMP2);

                // --- LMP3 ---
                CarClass LMU_LMP3 = new CarClass
                {
                    Name = "LMP3",
                    SimulationType = 1,
                    Cars = new List<Car>()
                        {
                new Car("Ligier JS P325")
                        }
                };
                carClasses.Add(LMU_LMP3);

                // --- Hypercar ---
                CarClass LMU_Hypercar = new CarClass
                {
                    Name = "Hypercar",
                    SimulationType = 1,
                    Cars = new List<Car>()
                    {
                new Car("Alpine A424"),
                new Car("Aston Martin Valkyrie AMR-LMH"),
                new Car("BMW M Hybrid V8"),
                new Car("Cadillac V-Series.R"),
                new Car("Ferrari 499P"),
                new Car("Glickenhaus SCG 007"),
                new Car("Isotta Fraschini Tipo 6"),
                new Car("Lamborghini SC63"),
                new Car("Peugeot 9X8"),
                new Car("Peugeot 9X8 2024"),
                new Car("Porsche 963"),
                new Car("Toyota GR010-Hybrid"),
                new Car("Vanwall Vandervell 680")
                    }
                };
                carClasses.Add(LMU_Hypercar);


                // --- GTE ---
                CarClass LMU_GTE = new CarClass
                {
                    Name = "GTE",
                    SimulationType = 1,
                    Cars = new List<Car>()
                        {
                new Car("Aston Martin Vantage AMR"),
                new Car("Chevrolet Corvette C8.R"),
                new Car("Ferrari 488 GTE Evo"),
                new Car("Porsche 911 RSR-19")
                        }
                };
                carClasses.Add(LMU_GTE);


                // ===========================
                //           ACC
                // ===========================

                // --- GT3 ---
                CarClass ACC_GT3 = new CarClass
                {
                    Name = "GT3",
                    SimulationType = 2,
                    Cars = new List<Car>()
                    {
                new Car("Aston Martin V8 Vantage GT3 2019"),
                new Car("Aston Martin V12 Vantage GT3 2013"),
                new Car("Audi R8 LMS GT3 2015"),
                new Car("Audi R8 LMS Evo GT3 2019"),
                new Car("Audi R8 LMS Evo II GT3 2022"),
                new Car("Bentley Continental GT3 2015"),
                new Car("Bentley Continental GT3 2018"),
                new Car("BMW M4 GT3"),
                new Car("BMW M6 GT3"),
                new Car("Emil Frey Jaguar GT3"),
                new Car("Ferrari 488 GT3 2018"),
                new Car("Ferrari 488 GT3 Evo 2020"),
                new Car("Ferrari 296 GT3 2023"),
                new Car("Honda NSX GT3 2017"),
                new Car("Honda NSX GT3 Evo 2019"),
                new Car("Lamborghini Huracán GT3 2015"),
                new Car("Lamborghini Huracán GT3 Evo 2019"),
                new Car("Lamborghini Huracán GT3 Evo II 2023"),
                new Car("Lexus RC F GT3"),
                new Car("McLaren 650S GT3 2015"),
                new Car("McLaren 720S GT3 2019"),
                new Car("McLaren 720S GT3 Evo 2023"),
                new Car("Mercedes AMG GT3 2015"),
                new Car("Mercedes AMG GT3 Evo 2020"),
                new Car("Nissan GT-R Nismo GT3 2015"),
                new Car("Nissan GT-R Nismo GT3 2018"),
                new Car("Porsche 911 GT3 R 2018"),
                new Car("Porsche 911 II GT3 R 2019"),
                new Car("Porsche 992 GT3 R 2023"),
                new Car("Reiter EngineeringR-EX GT3")
                    }
                };
                carClasses.Add(ACC_GT3);

                // --- GT4 ---
                CarClass ACC_GT4 = new CarClass
                {
                    Name = "GT4",
                    SimulationType = 2,
                    Cars = new List<Car>()
                        {
                new Car("Alpine A110 GT4"),
                new Car("Aston Martin Vantage GT4"),
                new Car("Audi R8 LMS GT4"),
                new Car("BMW M4 GT4"),
                new Car("Chevrolet Camaro GT4.R"),
                new Car("Ginetta G55 GT4"),
                new Car("KTM X-Bow GT4"),
                new Car("Maserati GranTurismo MC GT4"),
                new Car("McLaren 570S GT4"),
                new Car("Mercedes AMG GT4"),
                new Car("Porsche 718 Cayman GT4 Clubsport")
                        }
                };
                carClasses.Add(ACC_GT4);

                // --- GT2 ---
                CarClass ACC_GT2 = new CarClass
                {
                    Name = "GT2",
                    SimulationType = 2,
                    Cars = new List<Car>()
                            {
                new Car("Audi R8 LMS GT2"),
                new Car("KTM X-Bow GT2"),
                new Car("Maserati MC20 GT2"),
                new Car("Mercedes AMG GT2"),
                new Car("Porsche 991 II GT2 RS CS Evo"),
                new Car("Porsche 935 GT2") }
                };
                carClasses.Add(ACC_GT2);


                // --- BMW M2 ---
                CarClass ACC_M2 = new CarClass
                {
                    Name = "BMW M2",
                    SimulationType = 2,
                    Cars = new List<Car>()
                    {
                new Car("BMW M2 CS Racing") }
                };
                carClasses.Add(ACC_M2);

                // --- ST (Super Trofeo) ---
                CarClass ACC_ST = new CarClass
                {
                    Name = "ST (Super Trofeo)",
                    SimulationType = 2,
                    Cars = new List<Car>()
                    {
                new Car("Lamborghini Huracán Super Trofeo 2015"),
                new Car("Lamborghini Huracán Super Trofeo EVO2 2021"),
                    }
                };
                carClasses.Add(ACC_ST);

                // --- Ferrari Challenge ---
                CarClass ACC_Ferrari_Challenge = new CarClass
                {
                    Name = "Ferrari Challenge",
                    SimulationType = 2,
                    Cars = new List<Car>()
                    {
                new Car("Ferrari 488 Challenge Evo") }
                };
                carClasses.Add(ACC_Ferrari_Challenge);

                // --- Porsche Cup ---
                CarClass ACC_Cup = new CarClass
                {
                    Name = "Porsche Cup",
                    SimulationType = 2,
                    Cars = new List<Car>()
                    {
                new Car("Porsche 911 II GT3 Cup 2017"),
                new Car("Porsche 911 GT3 Cup (992)")
                    }
                };
                carClasses.Add(ACC_Cup);
                SaveCars(carClasses);

                ;
            }
            return carClasses;
        }
        public static void SaveCars(List<CarClass> cars)
        {
            string jsonText = JsonSerializer.Serialize(cars);
            File.WriteAllText("cars.json", jsonText);
        }
        public static async Task<List<CarClass>> GetAllCarClassesAsync()
        {
            List<CarClass> carClass = new List<CarClass>();
            string json = await File.ReadAllTextAsync("carClasses.json");
            JsonSerializer.Deserialize<List<CarClass>>(json)?.ForEach(c => carClass.Add(c));
            return carClass;

        }
    }
}
