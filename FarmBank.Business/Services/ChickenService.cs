//using System.Collections.Generic;
//using System.Linq;
//using BarnCase.Business.Interfaces;
//using BarnCase.Entities;

//namespace BarnCase.Business.Services
//{
//    public class ChickenService : IChickenService
//    {
//        private List<Chicken> chickens = new List<Chicken>();
//        private const int MaxChickens = 5;

//        public int CurrentChickenCount => chickens.Count;

//        public void AddChicken()
//        {
//            if (CurrentChickenCount < MaxChickens)
//            {
//                chickens.Add(new Chicken());
//            }
//            else
//            {
//                // Maksimum tavuk sayısına ulaşıldı.
//            }
//        }
        
//        public void RemoveDeadChickens()
//        {
//            chickens = chickens.Where(chicken => chicken.IsAlive()).ToList();
//        }

//        public void PassTime(int minutes)
//        {
//            foreach (var chicken in chickens)
//            {
//                chicken.PassTime(minutes);
//            }
//            RemoveDeadChickens();
//        }

//        public int GetTotalEggsProduced()
//        {
//            int totalEggs = 0;
//            foreach (var chicken in chickens)
//            {
//                totalEggs += chicken.EggsProduced;
//            }
//            return totalEggs;
//        }

//        public int SellEggs(int eggBatches)
//        {
//            int totalEggs = GetTotalEggsProduced();
//            int eggsToSell = eggBatches * Chicken.EggsPerBatch;
//            if (totalEggs >= eggsToSell)
//            {
//                // Yumurtalar satılıyor ve kazanç hesaplanıyor
//                int earnings = eggBatches * Chicken.EggPrice;
//                // Satılan yumurta miktarı azaltılıyor
//                foreach (var chicken in chickens)
//                {
//                    if (eggsToSell <= 0) break;
//                    if (chicken.EggsProduced > 0)
//                    {
//                        int eggsToSellNow = Math.Min(chicken.EggsProduced, eggsToSell);
//                        chicken.EggsProduced -= eggsToSellNow;
//                        eggsToSell -= eggsToSellNow;
//                    }
//                }
//                return earnings;
//            }
//            else
//            {
//                // Yeterli yumurta yok.
//                return 0;
//            }
//        }
//    }
//}


