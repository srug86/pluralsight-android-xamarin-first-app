using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Provider;
using Java.IO;
using Android.Graphics;
using RaysHotDogs.Utility;

namespace RaysHotDogs
{

    [Activity(Label = "Take a picture with Ray", Icon = "@drawable/smallicon")]
    public class TakePictureActivity: Activity
    {
        private ImageView rayPictureImageView;
        private Button takePictureButton;
        private File imageDirectory;
        private File imageFile;
        private Bitmap imageBitmap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TakePictureView);

            FindViews();

            HandleEvents();

            imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                Android.OS.Environment.DirectoryPictures), "RaysHotDogs");

            if (!imageDirectory.Exists())
            {
                imageDirectory.Mkdirs();
            }
        }

        private void FindViews()
        {
            rayPictureImageView = FindViewById<ImageView>(Resource.Id.rayPictureImageView);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            takePictureButton.Click += TakePictureButton_Click;
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            imageFile = new File(imageDirectory, String.Format("PhotoWithRay_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));

            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            int height = rayPictureImageView.Height;
            int width = rayPictureImageView.Width;
            imageBitmap = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, height);

                if (imageBitmap != null)
                {
                    rayPictureImageView.SetImageBitmap(imageBitmap);
                    imageBitmap = null;
                }

                //required to avoid memory leaks!
                GC.Collect();
        }


    }
}