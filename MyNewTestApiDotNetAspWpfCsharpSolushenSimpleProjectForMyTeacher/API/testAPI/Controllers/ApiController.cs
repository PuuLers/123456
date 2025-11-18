using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.Models;

namespace testAPI.Controllers;

[Route("api")]
[ApiController]
public partial class ApiController : ControllerBase
{
    private readonly AppDbContext _db;

    public ApiController(AppDbContext db) => _db = db;

    [HttpGet("staff")]
    public async Task<IActionResult> GetStaff()
    {
        var staffData = await _db.StaffPostDivision.ToListAsync();

        // Преобразуем в формат, ожидаемый WPF
        var employees = staffData.Select(s => new
        {
            FullName = s.FullName,
            Division = s.DivisionName,
            Post = s.PostName,
            WorkingPhone = s.WorkingPhone,
            MobilePhone = s.MobilePhone,
            OfficeNumber = s.OfficeNumber,
            CorporateEmail = s.CorporateEmailAddress,
            PersonalEmail = s.PersonalEmailAddress,
            OtherInformation = s.OtherInformation,
            Birthday = s.Birthday
        }).ToList();

        return Ok(employees);
    }

    [HttpGet("division")]
    public async Task<IActionResult> GetDivisions()
    {
        var divisions = await _db.Division
            .Select(d => new
            {
                id_division = d.id_division,
                DivisionName = d.DivisionName,
                DivisionDescription = d.DivisionDescription,
                id_parent = d.id_parent ?? 0,
                Level = d.sLevel ?? 0
            })
            .ToListAsync();

        return Ok(divisions);
    }

    [HttpPost("staff")]
    public async Task<IActionResult> CreateStaff(Staff staff)
    {
        _db.Staff.Add(staff);
        await _db.SaveChangesAsync();
        return Ok(staff);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _db.Users
            .Select(d => new
            {
                id_user = d.id_user,
                Name = d.Name,
                Password = d.Password,

            })
            .ToListAsync();

        return Ok(users);
    }

    [HttpPost("user")]
    public async Task<IActionResult> Signin([FromBody] LoginRequest request) 
    {
        //if (request == null || string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Password))
        //{
        //    return false;
        //}

        var user = await _db.Users.Where(x => x.Name == request.Name && x.Password == request.Password).FirstOrDefaultAsync();

        if (user == null)
            return NotFound();
        else
            return Ok(true); 
        }
    }
