using System;
using ScrollTest.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


namespace ScrollTest.Pages
{
    public partial class ScrollComponent
    {
        TouchPoint ReferencePoint = null;

        protected override Task OnInitializedAsync()
        {
            ListItems[0].ClassName = "_active";
            return base.OnInitializedAsync();
        }

        [Parameter]
        public List<ListItem> ListItems { get; set; }

        public void ActivateItem(ListItem listitem)
        {
            foreach(ListItem li in ListItems)
            {
                li.ClassName = "";
            }
            ListItems.Where(item => listitem == item).FirstOrDefault().ClassName = "_active";
            
        }

        public ListItem GetActiveItem()
        {
            return ListItems.Where(item => item.ClassName == "_active").FirstOrDefault() ;
        }

        //gets initial position before touching
        public void HandleStart(TouchEventArgs Touch)
        {
            ReferencePoint = Touch.TargetTouches[0];
        }

        public void HandleEnd(TouchEventArgs TouchEvent)
        {
            string message;
            ListItem listItem = null;

            try
            {
                if (ReferencePoint == null)
                {
                    message = "you didnt swipe you idiot";
                    Console.WriteLine(message);
                    return;
                }

                var endReferencePoint = TouchEvent.ChangedTouches[0];

                var diffX = ReferencePoint.ClientX - endReferencePoint.ClientX;
                var diffY = ReferencePoint.ClientY - endReferencePoint.ClientY;

                 // sliding horizontally
                if (Math.Abs(diffX) > Math.Abs(diffY))
                {
                    listItem = GetActiveItem();
                    // swiped left
                    if (diffX > 0)
                    {
                        message = "swiped left";
                        if (ListItems.IndexOf(listItem) == ListItems.Count - 1)
                        {
                            ActivateItem(ListItems[0]);
                        }
                        else
                        {
                            ActivateItem(ListItems[(ListItems.IndexOf(listItem) + 1)]);
                        }
                    }
                    // swiped right
                    else
                    {
                        message = "swiped right";
                        if (ListItems.IndexOf(listItem) == 0)
                        {
                            ActivateItem(ListItems[ListItems.Count - 1]);
                        }
                        else
                        {
                            ActivateItem(ListItems[(ListItems.IndexOf(listItem) - 1)]);
                        }

                    }
                }
                else
                {
                    // sliding vertically
                    if (diffY > 0)
                    {
                        // swiped up
                        message = "swiped up";
                    }
                    else
                    {
                        // swiped down
                        message = "swiped down";
                    }
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            Console.WriteLine("youuuuuuuuuuuu " + message);

        }

    }
}