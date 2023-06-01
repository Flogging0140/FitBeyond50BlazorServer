using BlazorServer2.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServer2.Pages.MiscComponents
{
    public partial class PostsWithPages
    {
        // posts passed in, could get another way here too <--
        [Parameter]
        public List<BlogPost> BlogPosts { get; set; } = default!;

        // Posts we are displaying
        public List<BlogPost> PostsToDisplay { get; set; } = default!;

        // for sorting posts
        public PostOrder OrderOfPosts { get; set; } = PostOrder.asc;
        public enum PostOrder
        {
            asc,
            desc
        }

        // change how many we want to show here, etc
        // TODO: could let user decide how many per page!
        private int pageSize = 3;
        private int pageNumber = 1;
        int displayRange = default!;

        protected override void OnInitialized()
        {
            // set to 1 initially
            HandleChangePage(1);

            // initalize range to show
            displayRange = Convert.ToInt32(Math.Ceiling(BlogPosts.Count() / Convert.ToDecimal(pageSize)));

            base.OnInitialized();
        }

        public void TogglePostOrder()
        {
            // toggle the sort order
            OrderOfPosts = OrderOfPosts == PostOrder.asc ? OrderOfPosts = PostOrder.desc : OrderOfPosts = PostOrder.asc;

            // order the blog posts
            BlogPosts = OrderOfPosts == PostOrder.desc
            ? BlogPosts.OrderByDescending(b => b.DateCreated).ToList()
            : BlogPosts.OrderBy(b => b.DateCreated).ToList();

            // toggle the displayed posts
            HandleChangePage(1);
        }

        // change what page shows
        private void HandleChangePage(int p)
        {
            // change page number
            pageNumber = p;

            // get objects, leave implicit
            var page = BlogPosts.Skip((p - 1) * pageSize).Take(pageSize);

            // set posts to display
            PostsToDisplay = page.ToList();
        }

        #region StackSource
        /*
        Link: https://stackoverflow.com/questions/61570342/blazor-component-paging
        Author: Ali Borjian
        Helpers: GeorgiG, Stef Heyenrath

        Example:

        6

        In Blazor you have full control over your DOM. As You are using EF so you can simply perform Skip and Take for your paging :

        private int pageSize = 100;
        private int pageNumber = 1;
        in HTML :

        for(int p = 1; p<= list.Count() / pageSize ; p++) {
        <button type="button" @onclick="(e=>HandleChangePage(p))">@p</button>
        }
        Handle Change Page :

        void HandleChangePage(int p) {
          pageNumber  = p;
          var page = list.Skip((p-1) * pageSize).Take(pageSize);
        }
        It's the easiest way to do paging,
        Now you can go ahead and create your paging list component
        Now you need to pass your list to the component as a parameter

        [Parameter]
        public List<ClassName> list {get;set;}

        If you want to work with a generic list look at Template context parameters

        Share
        Edit
        Follow
        answered May 3, 2020 at 8:35
        Ali Borjian's user avatar
        Ali Borjian
        9211010 silver badges1818 bronze badges
        1
        I'm not sure why this happens to me, but passing p to HandleChangePage is always the fully incremented value. I have to assign a new int and pass it in order to fix this issue, like so: int pageId = p; @onclick(() => HandleChangePage(pageId)) –
         GeorgiG
         Jun 10, 2021 at 11:34
        @GeorgiG See also github.com/dotnet/aspnetcore/issues/10138 –
         Stef Heyenrath
         Aug 24, 2021 at 22:14
        Also instead of list.Count() / pageSize, you should use Convert.ToInt32(Math.Ceiling(list.Count() / Convert.ToDecimal(pageSize))) –
         Stef Heyenrath
         Aug 24, 2021 at 22:17

        */
        #endregion
    }
}
