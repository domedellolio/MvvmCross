// MvxTabBarViewController.cs

// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
//
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.tvOS.Views;

namespace MvvmCross.tvOS.Views
{
    public class MvxTabBarViewController
        : MvxEventSourceTabBarController
          , IMvxTvosView
    {
        protected MvxTabBarViewController()
        {
            this.AdaptForBinding();
        }

        protected MvxTabBarViewController(IntPtr handle)
            : base(handle)
        {
            this.AdaptForBinding();
        }

        public object DataContext
        {
            get
            {
                // special code needed in TabBar because View is initialized during construction
                return BindingContext?.DataContext;
            }
            set { BindingContext.DataContext = value; }
        }

        public IMvxViewModel ViewModel
        {
            get { return DataContext as IMvxViewModel; }
            set { DataContext = value; }
        }

        public MvxViewModelRequest Request { get; set; }

        public IMvxBindingContext BindingContext { get; set; }
    }

    public class MvxTabBarViewController<TViewModel>
        : MvxTabBarViewController
          , IMvxTvosView<TViewModel> where TViewModel : class, IMvxViewModel
    {
        protected MvxTabBarViewController()
        {
        }

        protected MvxTabBarViewController(IntPtr handle)
            : base(handle)
        {
        }

        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}