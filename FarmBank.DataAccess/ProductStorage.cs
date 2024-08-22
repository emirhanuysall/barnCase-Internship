using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarnCase.Entities;

namespace BarnCase.DataAccess;

//Ürün Türleri
public enum ProductType
{
    Milk,
    Wool,
    Egg
}

//Üretim Durumları.
public enum ProgressStatus
{
    NotStarted = 0,
    InProgress = 1,
    Completed = 100
}
//Ürünlerle ilgili verileri depolayan statik sınıf.
public static class ProductStorage
{
    public static Dictionary<ProductType, int> ProductQuantities { get; set; } = new Dictionary<ProductType, int>
    {
        //Ürün miktarlarını başlatır.
        { ProductType.Milk, 0 },
        { ProductType.Wool, 0 },
        { ProductType.Egg, 0 }
    };

    public static Dictionary<ProductType, ProgressStatus> ProgressBars { get; set; } = new Dictionary<ProductType, ProgressStatus>
    {
        //Üretimlerin ilerleme durumunu başlatır.
        { ProductType.Milk, ProgressStatus.NotStarted },
        { ProductType.Wool, ProgressStatus.NotStarted },
        { ProductType.Egg, ProgressStatus.NotStarted }
    };
    //Toplam satışları saklayan değişken.
    public static int TotalSales { get; set; } = 0;
}

