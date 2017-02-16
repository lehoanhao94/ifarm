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
using iFarm.Entities;
using Android.Widget;

namespace HelloToolbar
{
    [Activity(Label = "DiseasesActivity")]
    public class DiseasesActivity : AppCompatActivity
    {
        #region VARIABLES

        [InjectView(Resource.Id.toolbar)]
        Android.Support.V7.Widget.Toolbar toolbar;

        [InjectView(Resource.Id.rvCategory)]
        RecyclerView rvDiseaseList;

        RecyclerView.LayoutManager mLayoutManager;
        DiseasesAdapter mDiseasesAdapter;
        List<Disease> mLstDiseases;
        private int mCategoryID;

        #endregion

        #region CONSTRUCTORS
        #endregion

        #region OVERRIDE FUNCTIONS

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            mCategoryID = Intent.GetIntExtra("CategoryID", 0);

            SetContentView(Resource.Layout.activity_Category);
            Cheeseknife.Inject(this);

            setupToolbar();

            mLstDiseases = new List<Disease>();
            for(int i = 0; i < 50; i ++)
            {
                mLstDiseases.Add(new Disease(i, "Sâu bệnh " + i));
            }

            mLayoutManager = new LinearLayoutManager(this);
            rvDiseaseList.SetLayoutManager(mLayoutManager);

            mDiseasesAdapter = new DiseasesAdapter(mLstDiseases);
            mDiseasesAdapter.ItemClick += OnItemClick;
            rvDiseaseList.SetAdapter(mDiseasesAdapter);


        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.home, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        #endregion

        #region EVENTS

        void OnItemClick(object sender, int position)
        {
            int photoNum = position + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }

        #endregion

        #region OTHERS

        private void setupToolbar()
        {
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "Cây cao su " + mCategoryID;

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
        }

        #endregion
    }

    public class DiseasesAdapter : RecyclerView.Adapter
    {
        public List<Disease> mLstDiseases;
        public event EventHandler<int> ItemClick;

        public DiseasesAdapter(List<Disease> lstDiseases)
        {
            mLstDiseases = lstDiseases;
        }

        public override int ItemCount
        {
            get
            {
                return mLstDiseases.Count;
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
            DiseaseItemViewHolder vh = holder as DiseaseItemViewHolder;

            // Load the photo image resource from the photo album:
            vh.Image.SetImageResource(Resource.Drawable.disease);
            vh.Caption.Text = mLstDiseases[position].Name;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.item_Category, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            DiseaseItemViewHolder vh = new DiseaseItemViewHolder(itemView, OnClick);
            return vh;
        }
    }

    public class DiseaseItemViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }

        public DiseaseItemViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            // Locate and cache view references:
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);

            itemView.Click += (sender, e) => listener(base.Position);
        }
    }
}