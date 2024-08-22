using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarnCase.Entities;

namespace BarnCase.DataAccess;

// Hayvanları listede depolayan statik sınıf
public static class AnimalStorage
{
    public static List<Animal> AnimalList { get; set; } = new List<Animal>();
}