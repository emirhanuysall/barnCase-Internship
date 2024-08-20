//using System.Collections.Generic;
//using System.Linq;
//using BarnCase.Business.Interfaces;
//using BarnCase.Entities;

//namespace BarnCase.Business.Services
//{
//    public class CowService : ICowService
//    {
//        private List<Cow> cows = new List<Cow>();
//        private const int MaxCows = 8;

//        public int CurrentCowCount => cows.Count;

//        public void AddCow()
//        {
//            if (CurrentCowCount < MaxCows)
//            {
//                cows.Add(new Cow());
//            }
//            else
//            {
//                // Maksimum inek sayısına ulaşıldı.
//            }
//        }

//        public void RemoveDeadCows()
//        {
//            cows = cows.Where(cow => cow.IsAlive()).ToList();
//        }

//        public void PassTime(int minutes)
//        {
//            foreach (var cow in cows)
//            {
//                cow.PassTime(minutes);
//            }
//            RemoveDeadCows();
//        }

//        public int GetTotalMilkProduced()
//        {
//            int totalMilk = 0;
//            foreach (var cow in cows)
//            {
//                totalMilk += cow.MilkProduced;
//            }
//            return totalMilk;
//        }

//        public int SellMilk(int liters)
//        {
//            int totalMilk = GetTotalMilkProduced();
//            if (totalMilk >= liters)
//            {
//                // Süt satılıyor ve kazanç hesaplanıyor
//                int earnings = liters * Cow.MilkPrice;
//                // Satılan süt miktarı azaltılıyor
//                foreach (var cow in cows)
//                {
//                    if (liters <= 0) break;
//                    if (cow.MilkProduced > 0)
//                    {
//                        int milkToSell = Math.Min(cow.MilkProduced, liters);
//                        cow.MilkProduced -= milkToSell;
//                        liters -= milkToSell;
//                    }
//                }
//                return earnings;
//            }
//            else
//            {
//                // Yeterli süt yok.
//                return 0;
//            }
//        }
//    }
//}
