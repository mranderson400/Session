using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session.Models;

namespace Session.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }




[HttpGet("/viewName")]
    public IActionResult ViewName()
    {
        String? newName = HttpContext.Session.GetString("newName");
       if (HttpContext.Session.GetInt32("Number") == null)
       {
            HttpContext.Session.SetInt32("Number", 22);

       }
       
        return View("ViewName");
}

[HttpGet("/Counter/Add")]
 public IActionResult CounterAdd()
    {
        var number = HttpContext.Session.GetInt32("Number");
        number ++;
        int newNumber = number.GetValueOrDefault();
        HttpContext.Session.SetInt32("Number", newNumber);

    return Redirect("/ViewName");
}
[HttpGet("/Counter/Sub")]
 public IActionResult CounterSub()
    {
        var number = HttpContext.Session.GetInt32("Number");
        number --;
        int newNumber = number.GetValueOrDefault();
        HttpContext.Session.SetInt32("Number", newNumber);

    return Redirect("/ViewName");
}

[HttpGet("/Counter/Times")]
 public IActionResult CounterTimes()
    {
        var number = HttpContext.Session.GetInt32("Number");
        number = number * 2;
        int newNumber = number.GetValueOrDefault();
        HttpContext.Session.SetInt32("Number", newNumber);

     return Redirect("/ViewName");

 }
[HttpGet("/Counter/Random")]
 public IActionResult CounterRandom()
    {
        var number = HttpContext.Session.GetInt32("Number");
        Random random = new Random();
        number = number + random.Next(11);
        int newNumber = number.GetValueOrDefault();
        HttpContext.Session.SetInt32("Number", newNumber);

    return Redirect("/ViewName");
}



[HttpPost("/addName")]
public IActionResult addName(NameModel newName)
{
    if(!ModelState.IsValid)
    {
        return View("Index");
    }

    // if (newName.Name == "rob")
    // {
    //     ViewBag.SecretMessage = "Hello robert";
    //     return View("Index");
    // }
    HttpContext.Session.SetString("name", newName.Name);
    // Console.WriteLine(newName.Name + "is a(n)" );
    // return RedirectToAction("Index"); 
    return Redirect("/ViewName");
}

[HttpPost("Logout")]
 public IActionResult Logout()
 {
    
    HttpContext.Session.Clear();
    
    
    return Redirect("/");
 }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
