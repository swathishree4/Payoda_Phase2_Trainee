using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_MAINTEST.Models;
using MVC_MAINTEST.Repository;
using MVC_MAINTEST.Service; 
using System.Linq;
using System.Threading.Tasks;

public class PostController : Controller
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public PostController(IPostRepository postRepository, IUserRepository userRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    // GET: Posts
    public async Task<IActionResult> Index()
    {
        var posts = await _postRepository.GetAllPostsAsync();
        return View(posts);
    }

    // GET: Posts/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);
        if (post == null) return NotFound();

        return View(post);
    }

    // GET: Posts/Create
    public async Task<IActionResult> Create()
    {
       
        //ViewBag.uId = new SelectList(await _userRepository.GetAllUsersAsync(), "uId", "Username");
        return View();
    }

    // POST: Posts/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Content,UserId")] Post post)
    {

        ////ViewBag.Users = new SelectList(await _userRepository.GetAllUsersAsync(), "uId", "Username", post.uId);
       // post.uId = (int)ViewBag.Users;
        post.CreatedDate = DateTime.Now;
            await _postRepository.AddPostAsync(post);
            return RedirectToAction(nameof(Index));
        
       
       
    }

    // GET: Posts/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);
        if (post == null) return NotFound();

       
        //ViewBag.UserId = new SelectList(await _userRepository.GetAllUsersAsync(), "uId", "Username", post.UserId);
        return View(post);
    }

    // POST: Posts/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("PostId,Title,Content,UserId,CreatedDate")] Post post)
    {
        if (id != post.PostId) return NotFound();

        try
            {
                await _postRepository.UpdatePostAsync(post);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _postRepository.GetPostByIdAsync(id) == null) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        
        //ViewBag.Users = new SelectList(await _userRepository.GetAllUsersAsync(), "uId", "Username", post.UserId);
        return View(post);
    }

    // GET: Posts/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);
        if (post == null) return NotFound();

        return View(post);
    }

    // POST: Posts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _postRepository.DeletePostAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
