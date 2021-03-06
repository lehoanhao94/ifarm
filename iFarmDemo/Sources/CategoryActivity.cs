﻿using System;
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
using iFarm.Entities;
using Android.Widget;

namespace HelloToolbar
{
    [Activity(Label = "CategoryActivity")]
    public class CategoryActivity : AppCompatActivity
    {
        #region VARIABLES

        [InjectView(Resource.Id.toolbar)]
        Android.Support.V7.Widget.Toolbar toolbar;

        [InjectView(Resource.Id.rvCategory)]
        RecyclerView rvCategoryList;

        RecyclerView.LayoutManager mLayoutManager;
        CategoryAdapter mCategoryAdapter;
        List<Category> mLstCategory;
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

            prepareDemoData();

            mLayoutManager = new LinearLayoutManager(this);
            rvCategoryList.SetLayoutManager(mLayoutManager);

            mCategoryAdapter = new CategoryAdapter(mLstCategory);
            mCategoryAdapter.ItemClick += OnItemClick;
            rvCategoryList.SetAdapter(mCategoryAdapter);


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.home, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }

        #endregion

        #region EVENTS

        void OnItemClick(object sender, int position)
        {
            int photoNum = position + 1;
            var activity = new Intent(this, typeof(DiseasesActivity));
            activity.PutExtra("CategoryID", mLstCategory[position].Id);
            StartActivity(activity);
        }

        #endregion

        #region OTHERS

        private void prepareDemoData()
        {
            mLstCategory = new List<Category>();

            List<Disease> _lstDisease = new List<Disease>();
            _lstDisease.Add(new Disease(1, "Thối gốc 1"));
            _lstDisease.Add(new Disease(2, "Thối gốc 2"));        
            _lstDisease.Add(new Disease(3, "Thối gốc 3"));
            _lstDisease.Add(new Disease(4, "Thối gốc 4"));
            _lstDisease.Add(new Disease(5, "Thối gốc 5"));
            _lstDisease.Add(new Disease(6, "Thối gốc 6"));
            _lstDisease.Add(new Disease(7, "Thối gốc 7"));
          
            for(int i = 0; i < 100; i ++)
            {
                mLstCategory.Add(new Category(i, "Cây cao su " + i, "http://www.caosubinhduong.com.vn/images/news/cao-su-nuoc.jpg", _lstDisease));
            }
                    
        }

        private void setupToolbar()
        {
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "Cây công nghiệp";

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
        }

        #endregion
    }

    public class CategoryAdapter : RecyclerView.Adapter
    {
        public List<Category> mLstCategory;
        public event EventHandler<int> ItemClick;

        public CategoryAdapter(List<Category> lstCategory)
        {
            mLstCategory = lstCategory;
        }

        public override int ItemCount
        {
            get
            {
                return mLstCategory.Count;
            }
        }
        void OnClick(int position)
        {
            if (ItemClick != null)
            {               
                ItemClick(this, position);
            }              
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            CategoryItemViewHolder vh = holder as CategoryItemViewHolder;

            // Load the photo image resource from the photo album:
            vh.Image.SetImageResource(Resource.Drawable.tree);
            vh.Caption.Text = mLstCategory[position].Name;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.item_Category, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            CategoryItemViewHolder vh = new CategoryItemViewHolder(itemView, OnClick);
            return vh;
        }
    }

    public class CategoryItemViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }

        public CategoryItemViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            // Locate and cache view references:
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);

            itemView.Click += (sender, e) => listener(base.Position);
        }
    }
}