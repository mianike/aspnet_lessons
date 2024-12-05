using Microsoft.AspNetCore.Mvc;

namespace CarSpecificationsAPI.Controllers
{
    [ApiController]
    [Route("car")]
    public class CarsController : ControllerBase
    {
        // This is a crutch. Emulation of the car database
        private readonly Dictionary<string, Dictionary<string, dynamic>> _carSpecifications = new()
        {
            { "toyota", new Dictionary<string, dynamic>
                {
                    { "supra", new { Model = "Supra", MaxSpeed = "250 км/ч", MaxPower = 340, EngineVolume = "3.0 л", FuelConsumption = "7.5 л/100 км" } },
                    { "camry", new { Model = "Camry", MaxSpeed = "210 км/ч", MaxPower = 249, EngineVolume = "2.5 л", FuelConsumption = "8.1 л/100 км" } },
                    { "corolla", new { Model = "Corolla", MaxSpeed = "190 км/ч", MaxPower = 140, EngineVolume = "1.6 л", FuelConsumption = "6.5 л/100 км" } }
                }
            },
            { "audi", new Dictionary<string, dynamic>
                {
                    { "rs7", new { Model = "RS7", MaxSpeed = "305 км/ч", MaxPower = 600, EngineVolume = "4.0 л", FuelConsumption = "12.5 л/100 км" } },
                    { "a4", new { Model = "A4", MaxSpeed = "240 км/ч", MaxPower = 265, EngineVolume = "2.0 л", FuelConsumption = "7.3 л/100 км" } },
                    { "q5", new { Model = "Q5", MaxSpeed = "230 км/ч", MaxPower = 245, EngineVolume = "2.0 л", FuelConsumption = "8.4 л/100 км" } }
                }
            },
            { "bmw", new Dictionary<string, dynamic>
                {
                    { "m5", new { Model = "M5 Competition", MaxSpeed = "305 км/ч", MaxPower = 625, EngineVolume = "4.4 л", FuelConsumption = "11.1 л/100 км" } },
                    { "x5", new { Model = "X5", MaxSpeed = "250 км/ч", MaxPower = 400, EngineVolume = "3.0 л", FuelConsumption = "9.0 л/100 км" } },
                    { "z4", new { Model = "Z4", MaxSpeed = "240 км/ч", MaxPower = 340, EngineVolume = "3.0 л", FuelConsumption = "7.1 л/100 км" } }
                }
            },
            { "mercedes", new Dictionary<string, dynamic>
                {
                    { "e63", new { Model = "E63 AMG", MaxSpeed = "300 км/ч", MaxPower = 612, EngineVolume = "4.0 л", FuelConsumption = "10.8 л/100 км" } },
                    { "c200", new { Model = "C200", MaxSpeed = "240 км/ч", MaxPower = 204, EngineVolume = "1.5 л", FuelConsumption = "7.0 л/100 км" } },
                    { "gle63", new { Model = "GLE63 AMG", MaxSpeed = "280 км/ч", MaxPower = 612, EngineVolume = "4.0 л", FuelConsumption = "12.0 л/100 км" } }
                }
            },
            { "skoda", new Dictionary<string, dynamic>
                {
                    { "octavia", new { Model = "Octavia", MaxSpeed = "220 км/ч", MaxPower = 190, EngineVolume = "2.0 л", FuelConsumption = "6.4 л/100 км" } },
                    { "kodiaq", new { Model = "Kodiaq", MaxSpeed = "205 км/ч", MaxPower = 180, EngineVolume = "2.0 л", FuelConsumption = "7.5 л/100 км" } },
                    { "superb", new { Model = "Superb", MaxSpeed = "250 км/ч", MaxPower = 272, EngineVolume = "2.0 л", FuelConsumption = "7.1 л/100 км" } }
                }
            }
        };

        // Method for getting the most powerful model from a given brand
        [HttpGet("{brand}")]
        public IActionResult GetMostPowerfulModelInBrand(string brand)
        {
            if (_carSpecifications.TryGetValue(brand.ToLower(), out var modelsDict))
            {
                var mostPowerfulModel = modelsDict
                    .OrderByDescending(m => m.Value.MaxPower)
                    .FirstOrDefault();

                if (mostPowerfulModel.Value != null)
                {
                    return Ok(mostPowerfulModel.Value);
                }

                return NotFound($"No models found for brand {brand}.");
            }

            return NotFound($"Brand {brand} not found.");
        }

        // Method for obtaining characteristics of the specified models
        // Note: Swagger escapes the / character in %2F, so if it doesn't work in Swagger, enter the URL in the search box
        [HttpGet("{brand}/{*models}")]
        public IActionResult GetSpecificModels(string brand, string models)
        {
            if (_carSpecifications.TryGetValue(brand.ToLower(), out var modelsDict))
            {
                // Split the line with models
                var requestedModels = models
                    .Split("/", StringSplitOptions.RemoveEmptyEntries)
                    .Select(m => m.ToLower())
                    .ToList();

                var availableModels = modelsDict
                    .Where(m => requestedModels.Contains(m.Key))
                    .Select(m => m.Value)
                    .ToList();

                if (availableModels.Any())
                {
                    return Ok(availableModels);
                }

                return NotFound($"Models {string.Join(", ", requestedModels)} of brand {brand} not found.");
            }

            return NotFound($"Brand {brand} not found.");
        }
    }
}
