using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Com.Lilarcor.Cheeseknife;

namespace HelloToolbar.Sources
{
    [Activity(Label = "CategoryActivity")]
    public class CategoryActivity : AppCompatActivity
    {
        #region VARIABLES

        [InjectView(Resource.Id.toolbar)]
        Toolbar toolbar;

        [InjectView(Resource.Id.rvCategory)]
        RecyclerView rvCategoryList;

        RecyclerView.LayoutManager mLayoutManager;
        //PhotoAlbumAdapter mAdapter;
        //PhotoAlbum mPhotoAlbum;
        #endregion

        #region CONSTRUCTORS
        #endregion

        #region OVERRIDE FUNCTIONS

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_Category);
            Cheeseknife.Inject(this);

            setupToolbar();
        }  
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }

        #endregion

        #region EVENTS

        #endregion

        #region OTHERS

        private void setupToolbar()
        {
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "Cây công nghiệp";

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
        }

        #endregion
    }
}