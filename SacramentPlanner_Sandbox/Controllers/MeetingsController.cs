using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner_Sandbox.Data;
using SacramentPlanner_Sandbox.Models;
using SacramentPlanner_Sandbox.Models.MeetingViewModels;

namespace SacramentPlanner_Sandbox.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly MeetingContext _context;

        public MeetingsController(MeetingContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meeting.ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .Include(s => s.Speakers)
                .SingleOrDefaultAsync(m => m.MeetingID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);

            //var viewModel = new MeetingIndexData();

            //viewModel.Meetings = await _context.Meeting
            //    .AsNoTracking()
            //    .ToListAsync();

            //if (viewModel.Meetings == null)
            //{
            //    return NotFound();
            //}

            //if (id != null)
            //{
            //    Meeting meeting = viewModel.Meetings.Where(i => i.MeetingID == id.Value).Single();
            //    viewModel.Speakers = meeting.Speakers.Select(s => s.MeetingID);
            //}

            //viewModel.Meetings = await _context.Meeting;
            //foreach 
            //    .Include(i => i.MeetingID)
            //    .Include(i => i.OpeningHymn)
            //        .ThenInclude()
            //    .ToListAsync();

        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            PopulateMemberDropDownList();
            PopulateBishopricDropDownList();
            PopulateHymnDropDownList();
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingID,MeetingDate,Conducting,OpeningHymn,OpeningPrayer,SacramentHymn,IntermediateSong,ClosingHymn,ClosingPrayer")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateMemberDropDownList(meeting.MeetingID);
            PopulateBishopricDropDownList(meeting.MeetingID);
            PopulateHymnDropDownList(meeting.MeetingID);
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.MeetingID == id);
            if (meeting == null)
            {
                return NotFound();
            }
            PopulateMemberDropDownList();
            PopulateBishopricDropDownList();
            PopulateHymnDropDownList();
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeetingID,MeetingDate,Conducting,OpeningHymn,OpeningPrayer,SacramentHymn,IntermediateSong,ClosingHymn,ClosingPrayer")] Meeting meeting)
        {
            if (id != meeting.MeetingID)
            {
                return NotFound();
            }

            var meetingToUpdate = await _context.Meeting
                .SingleOrDefaultAsync(m => m.MeetingID == id);

            if (await TryUpdateModelAsync<Meeting>(meetingToUpdate, ""
                , m => m.MeetingDate
                , m => m.Conducting
                , m => m.OpeningHymn
                , m => m.OpeningPrayer
                , m => m.SacramentHymn
                , m => m.IntermediateSong
                , m => m.ClosingHymn
                , m => m.ClosingPrayer
                ))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your administrator.");
                }
                return RedirectToAction(nameof(Index));
            }

            PopulateMemberDropDownList(meeting.MeetingID);
            PopulateBishopricDropDownList(meeting.MeetingID);
            PopulateHymnDropDownList(meeting.MeetingID);
            return View(meeting);

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(meeting);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!MeetingExists(meeting.MeetingID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .SingleOrDefaultAsync(m => m.MeetingID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meeting.SingleOrDefaultAsync(m => m.MeetingID == id);
            _context.Meeting.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.MeetingID == id);
        }


        private void PopulateMemberDropDownList(object selectedMeeting = null)
        {
            var personQuery = from d in _context.Person
                              orderby d.LastName
                              select d;
            ViewBag.MemberID = new SelectList(personQuery.AsNoTracking(), "PersonID", "FullName", selectedMeeting);
        }

        private void PopulateBishopricDropDownList(object selectedMeeting = null)
        {
            var personQuery = from d in _context.Person
                              where d.Discriminator == "Bishopric"
                              orderby d.LastName
                              select d;
            ViewBag.BishopricID = new SelectList(personQuery.AsNoTracking(), "PersonID", "FullName", selectedMeeting);
        }

        private void PopulateHymnDropDownList(object selectedMeeting = null)
        {
            var hymnQuery = from h in _context.Hymn
                            orderby h.HymnName
                            select h;
            ViewBag.HymnID = new SelectList(hymnQuery.AsNoTracking(), "HymnID", "HymnName");
        }
    }
}
