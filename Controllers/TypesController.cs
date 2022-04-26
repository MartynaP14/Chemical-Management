using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chemical_Management.Data;
using Chemical_Management.Models;

namespace Chemical_Management.Controllers
{
    public class TypesController : Controller
    {
        //nothing added because current context only understand the old data model and is throwing errors for reagent type and vendor properies in reagents,
        //error CS1061: 'Supply' does not contain a definition for 'ReagnetNumber' -> old property name now called reagent stock
    }
}
