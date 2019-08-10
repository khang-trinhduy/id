using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Contact.Class;
using Contact.Class.Apartments;
using Contact.View;
using Identity_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace Identity_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IdentityDbContext _context;
        public ContactsController(IdentityDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpGet]
        // [Route("contacts")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Contact.Class.Contact>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery]int pageSize = 10,
                                             [FromQuery] int pageIndex = 0)
        {
            var totalContacts = await _context.Contact
                    .LongCountAsync();
            
            var contactsOnPage = await _context.Contact
                    .OrderBy(e => e.FullName)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                    
            return Ok(contactsOnPage);

        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Import()
        {
            return Ok();
        }

        [HttpPost]
        [Route("import")]
        public IActionResult Import(IFormFile file)
        {
            if (file == null)
            {
                return NotFound();
            }

            if (file.Length < 0)
            {
                return NotFound("cannot read file");
            }

            var path = Path.GetTempFileName();
            using (var reader = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(reader);
            }
            FileInfo fileInfo = new FileInfo(path);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.First(e => true);

                int totalRows = sheet.Dimension.Rows;

                List<Contact.Class.Contact> contacts = new List<Contact.Class.Contact>();

                for (int i = 2; i < totalRows; i++)
                {
                    Contact.Class.Contact contact = new Contact.Class.Contact();

                    try
                    {
                        var name = sheet.Cells[i, 1].Value.ToString();
                        var gender = sheet.Cells[i, 2].Value.ToString();
                        var phone = sheet.Cells[i, 3].Value.ToString();
                        var dob = sheet.Cells[i, 4].Value.ToString();
                        // var email = sheet.Cells[i, 5].Value.ToString();
                        // var avatar = sheet.Cells[i, 6].Value.ToString();    
                        var cmnd = sheet.Cells[i, 7].Value.ToString();
                        var authorizedDate = sheet.Cells[i, 8].Value.ToString();
                        var authorizedBy = sheet.Cells[i, 9].Value.ToString();
                        // var job = sheet.Cells[i, 10].Value.ToString();
                        // var workPlace = sheet.Cells[i, 11].Value.ToString();
                        var contractNumber = sheet.Cells[i, 12].Value.ToString();
                        var productType = sheet.Cells[i, 13].Value.ToString();
                        var quantity = sheet.Cells[i, 14].Value.ToString();
                        var purpose = sheet.Cells[i, 15].Value.ToString();
                        var priority = sheet.Cells[i, 16].Value.ToString();
                        var sale = sheet.Cells[i, 17].Value.ToString();
                        var deposit = sheet.Cells[i, 18].Value.ToString();
                        var loan = sheet.Cells[i, 19].Value.ToString();
                        var depositType = sheet.Cells[i, 20].Value.ToString();  
                        var direction = sheet.Cells[i, 21].Value.ToString();
                        var view = sheet.Cells[i, 22].Value.ToString();
                        var floor = sheet.Cells[i, 23].Value.ToString();
                        var area = sheet.Cells[i, 24].Value.ToString();
                        // var bookingTime = sheet.Cells[i, 25].Value.ToString();
                        // var depositeTime = sheet.Cells[i, 26].Value.ToString();
                        var address = sheet.Cells[i, 27].Value.ToString();
                        var residence = sheet.Cells[i, 28].Value.ToString();
                        // var cmndFront = sheet.Cells[i, 29].Value.ToString();
                        // var cmndRear = sheet.Cells[i, 30].Value.ToString();
                        // var apartmentPhoto = sheet.Cells[i, 31].Value.ToString();
                        // var nationality = sheet.Cells[i, 32].Value.ToString();
                        // var withdraw = sheet.Cells[i, 33].Value.ToString();
                        // var wdDate = sheet.Cells[i, 34].Value.ToString();
                        // var wdType = sheet.Cells[i, 35].Value.ToString();
                        // var note = sheet.Cells[i, 36].Value.ToString();

                        if (name != null && phone != null && cmnd != null)
                        {
                            contact = _context.Contact.FirstOrDefault(e => e.FullName == name);
                            if (contact == null)
                            {
                                contact = new Contact.Class.Contact();
                            }
                            contact.FullName = name;
                            contact.Phone = phone;
                            // contact.Email = email;

                            if (contact.Product == null)
                            {
                                contact.Product = new List<Product>();
                            }
                        }

                        if (cmnd != null && authorizedBy != null)
                        {
                            if (cmnd.Length == 9)
                            {
                                var identity = new LocalIdentityCard{
                                    Number = cmnd,
                                    AuthorizedDate = DateTime.Parse(authorizedDate),
                                    AuthorizedBy = authorizedBy,
                                    DOB = DateTime.Parse(dob),
                                    Residence = residence,
                                    // Photo = cmndFront + " " + cmndRear
                                };
                                contact.Identity = identity;
                            }
                            else
                            {
                                var identity = new Passport{
                                    Number = cmnd,
                                    AuthorizedBy = authorizedBy,
                                    AuthorizedDate = DateTime.Parse(authorizedDate),
                                    // Nationality = nationality,
                                    // Photo = cmndFront,
                                    DOB = DateTime.Parse(dob),
                                    Gender = gender == "male" ? Contact.Enum.Gender.Male : Contact.Enum.Gender.Female
                                };
                                contact.Identity = identity;
                            }
                        }

                        if (productType != null)
                        {
                            switch (productType.ToLower())
                            {
                                case "s":
                                    var studio = new StudioApartment(Convert.ToDouble(deposit), "Studio", direction, view, Convert.ToInt16(floor), Convert.ToDouble(area));
                                    contact.Product.Add(studio);
                                    break;
                                case "1":
                                    var onebr = new OneBedroomApartment(Convert.ToDouble(deposit), "Studio", direction, view, Convert.ToInt16(floor), Convert.ToDouble(area));
                                    contact.Product.Add(onebr);
                                    break;
                                case "2":
                                    var twobr = new TwoBedroomApartment(Convert.ToDouble(deposit), "Studio", direction, view, Convert.ToInt16(floor), Convert.ToDouble(area));
                                    contact.Product.Add(twobr);
                                    break;
                                case "2+":
                                    var twobrp = new TwoBedroomPlusApartment(Convert.ToDouble(deposit), "Studio", direction, view, Convert.ToInt16(floor), Convert.ToDouble(area));
                                    contact.Product.Add(twobrp);
                                    break;
                                case "3":
                                    var threebr = new ThreeBedroomApartment(Convert.ToDouble(deposit), "Studio", direction, view, Convert.ToInt16(floor), Convert.ToDouble(area));
                                    contact.Product.Add(threebr);
                                    break;
                                default:
                                    break;
                            }
                        }
                        contacts.Add(contact);
                    }
                    catch (System.Exception ex)
                    {
                        return NotFound($"an error occurred while importing {ex.Message}");
                    }
                }

                foreach (var item in contacts)
                {
                    var temp = _context.Contact.FirstOrDefault(e => e.FullName == item.FullName);

                    if (temp != null)
                    {   
                        //TODO existed
                        // if (item.Identity != null)
                        // {
                        //     if (temp.Identity != null)
                        //     {
                        //         temp.Identity = item.Identity;
                        //     }
                        // }
                        // temp = item;

                        // _context.Entry(temp).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Contact.Add(item);
                    }
                }

                _context.SaveChanges();

                return Ok($"updated {contacts.Count} rows");
            }

        }
    }
}