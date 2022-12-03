using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebRaoVat.Data;
using WebRaoVat.Models;
using WebRaoVat.Models.Request;
using WebRaoVat.Services;
using WebRaoVat.ViewModels;

namespace WebRaoVat.Controllers
{
    public class AccountsController : Controller
    {
        private readonly DataContext _context;
        private readonly IAccountService _accountService;

        public AccountsController(DataContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            var result = _accountService.GetAllAccount();
            return View(result);
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Login
        public IActionResult Register()
        {
            ViewData["Cities"] = _context.Cities.ToList();
            return View();
        }
        // GET: Accounts/Create
        public IActionResult Login()
        {
            return View();
        }
        // GET: Accounts/Create
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("FirstName,LastName,Email,Password,CityId")] Account account)
        {
            //var _account = await _accountService.RegisterAccount(account);

            //if(_account != null)
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //ResultViewModel _result = new ResultViewModel
            //{
            //    IsError = true,
            //    Message = "Dang ky tai khoan khong thanh cong!!!",
            //    Data = null
            //};
            //return Ok(_result);

            account.Password = _accountService.GetMD5(account.Password) ;
            account.RoleId = 1;
            var _email = _context.Accounts.Select(a => a.Email);
            
            _context.Add(account);
            await _context.SaveChangesAsync();

            var result = _accountService.GetAccountById(account.Id);
            if(result == null)
            {
                
                return RedirectToAction(nameof(Login));
            }
            ResultViewModel _result = new ResultViewModel 
            {
                IsError = true,
                Message = "Dang ky tai khoan khong thanh cong!!!",
                Data = null
            };
            ViewData["Cities"] = _context.Cities.ToList();
            ViewData["Result"]= _result;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] AccountRequest accountRequest)
        {
            if(accountRequest == null)
            {
                ResultViewModel _result = new ResultViewModel
                {
                    IsError = true,
                    Message = "vui long nhap day du thong tin!!!",
                    Data = null
                };
                return Ok(_result);
            }
            var data = _accountService.LoginAccount(accountRequest);

            if (data != null)
            {
                //add session
                HttpContext.Session.SetString("FullName", data.FullName());
                HttpContext.Session.SetInt32("IdUser", data.Id);
                HttpContext.Session.SetString("Email", data.Email);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("Login");
            }
            return View();

        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id) ;
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idUser,FirstName,LastName,Email,Password")] Account account)
        {
            var accountEdit =  _accountService.GetAccountById(account.Id);
            if (accountEdit == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    _accountService.UpdateAccount(account);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelState.IsValid)
                    {
                        return View(account);
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
        }


            // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'DataContext.Accounts'  is null.");
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
