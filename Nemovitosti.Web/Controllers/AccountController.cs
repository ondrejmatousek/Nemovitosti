using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.ServiceLayer.Interface;
using Nemovitosti.Web.Mappers;
using Nemovitosti.Web.Models.Account;
using System;

namespace Nemovitosti.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUzivatelService _uzivatelService;
        private readonly IMapperWeb _mapperWeb;

        public AccountController(IUzivatelService uzivatelService, IMapperWeb mapperWeb)
        {
            _uzivatelService = uzivatelService;
            _mapperWeb = mapperWeb;
        }

        public IActionResult PresmerujNaRegister()
        {
            return View("Register");
        }

        public IActionResult UlozRegistraci(UzivatelVM uzivatelVM)
        {
            Uzivatel uzivatel = _mapperWeb.Map(uzivatelVM);
            if (ModelState.IsValid)
            {
                TempData["colorBorder"] = "border-success";
                TempData["colorMessage"] = "alert-success";

                if (uzivatelVM.IdUzivatel == 0)
                {
                    try
                    {
                        _uzivatelService.Insert(uzivatel);
                        TempData["shortMessage"] = "Registrace proběhla úspěšně";
                    }
                    catch (Exception Ex)
                    {
                        TempData["colorBorder"] = "border-warning";
                        TempData["shortMessage"] = Ex.Message;
                        TempData["colorMessage"] = "alert-warning";
                    }
                }
                else
                {
                    try
                    {
                        _uzivatelService.Update(uzivatel);
                        TempData["shortMessage"] = "Záznam byl úspěšně uložen";
                    }
                    catch (Exception Ex)
                    {
                        TempData["colorBorder"] = "border-warning";
                        TempData["shortMessage"] = Ex.Message;
                        TempData["colorMessage"] = "alert-warning";
                    }
                }
            }
            if (uzivatel.IdUzivatel == 0)
            {
                ViewBag.Message = TempData["shortMessage"];
                ViewBag.colorMessage = TempData["colorMessage"];
                ViewBag.colorBorder = TempData["colorBorder"];
                return View("Register", uzivatelVM);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult PresmerujNaLogin()
        {
            return View("Prihlaseni");
        }

        public IActionResult Prihlasit(UzivatelVM uzivatelVM)
        {
            Uzivatel uzivatel = _mapperWeb.Map(uzivatelVM);
            //Protože pro přihlášení používáme pouze Email a Pass, ostatní jsou null a to ModelState vyhodnotí jako, že je tam chyba(Protože Jmeno a přijmeni jsou required, proto odstraníme ModelState.
            ModelState.Remove("Jmeno");
            ModelState.Remove("Prijmeni");
            if (ModelState.IsValid)
            {
                TempData["colorBorder"] = "border-success";
                TempData["colorMessage"] = "alert-success";
                try
                {
                    Uzivatel uzivatelZDb = _uzivatelService.GetByEmailAndPassword(uzivatel);
                    if (uzivatelZDb != null)
                    {
                        TempData["shortMessage"] = "Přihlášení proběhlo úspěšně";
                        HttpContext.Session.SetString("SessionUserEmail", uzivatelZDb.Email);
                        HttpContext.Session.SetInt32("SessionUserId", uzivatelZDb.IdUzivatel);
                    }
                    else
                    {
                        TempData["colorBorder"] = "border-danger";
                        TempData["colorMessage"] = "alert-danger";
                        TempData["shortMessage"] = "Tento uživatel není zaregistrován";
                        ViewBag.Message = TempData["shortMessage"];
                        ViewBag.colorMessage = TempData["colorMessage"];
                        ViewBag.colorBorder = TempData["colorBorder"];
                        return View("Prihlaseni", uzivatelVM);
                    }
                }
                catch (Exception Ex)
                {
                    TempData["colorBorder"] = "border-warning";
                    TempData["shortMessage"] = Ex.Message;
                    TempData["colorMessage"] = "alert-warning";
                }
            }
            else
            {
                return View("Prihlaseni", uzivatelVM);
            }
            ViewBag.Message = TempData["shortMessage"];
            ViewBag.colorMessage = TempData["colorMessage"];
            ViewBag.colorBorder = TempData["colorBorder"];
            return View("Account", uzivatelVM);
        }

        public IActionResult Odhlasit()
        {
            HttpContext.Session.Clear();
            TempData["colorBorder"] = "border-success";
            TempData["shortMessage"] = "Uživatel byl odhlášen";
            TempData["colorMessage"] = "alert-success";
            return RedirectToAction("Index", "Home");
        }
    }
}
