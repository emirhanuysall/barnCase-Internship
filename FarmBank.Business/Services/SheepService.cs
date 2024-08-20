//using System.Collections.Generic;
//using System.Linq;
//using BarnCase.Business.Interfaces;
//using BarnCase.Entities;

//namespace BarnCase.Business.Services
//{
//    public class SheepService : ISheepService
//    {
//        private List<Sheep> sheeps = new List<Sheep>();
//        private const int MaxSheeps = 10;

//        public int CurrentSheepCount => sheeps.Count;

//        public void AddSheep()
//        {
//            if (CurrentSheepCount < MaxSheeps)
//            {
//                sheeps.Add(new Sheep());
//            }
//            else
//            {
//                // Maksimum koyun sayısına ulaşıldı.
//            }
//        }

//        public void RemoveDeadSheeps()
//        {
//            sheeps = sheeps.Where(sheep => sheep.IsAlive()).ToList();
//        }

//        public void PassTime(int minutes)
//        {
//            foreach (var sheep in sheeps)
//            {
//                sheep.PassTime(minutes);
//            }
//            RemoveDeadSheeps();
//        }

//        public int GetTotalWoolProduced()
//        {
//            int totalWool = 0;
//            foreach (var sheep in sheeps)
//            {
//                totalWool += sheep.WoolProduced;
//            }
//            return totalWool;
//        }

//        public int SellWool(int kilograms)
//        {
//            int totalWool = GetTotalWoolProduced();
//            if (totalWool >= kilograms)
//            {
//                // Yün satılıyor ve kazanç hesaplanıyor
//                int earnings = kilograms * Sheep.WoolPrice;
//                // Satılan yün miktarı azaltılıyor
//                foreach (var sheep in sheeps)
//                {
//                    if (kilograms <= 0) break;
//                    if (sheep.WoolProduced > 0)
//                    {
//                        int woolToSell = Math.Min(sheep.WoolProduced, kilograms);
//                        sheep.WoolProduced -= woolToSell;
//                        kilograms -= woolToSell;
//                    }
//                }
//                return earnings;
//            }
//            else
//            {
//                // Yeterli yün yok.
//                return 0;
//            }
//        }
//    }
//}


