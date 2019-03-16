﻿using System;
using System.Windows.Forms;

namespace WinFormsMVC
{
    public abstract class BaseController
    {

        public abstract IView View { get; }

        public event EventHandler LoadSuccess, LoadFailed;

        public BaseController()
        {
            LoadSuccess += OnLoadSucceededHandler;
            LoadFailed += OnLoadFailedHandler;
        }

        public abstract bool Loadable();

        protected virtual void OnLoadSucceededHandler(Object sender, EventArgs e)
        {
            AppManager.Instance.Show(this);
        }

        protected virtual void OnLoadFailedHandler(Object sender, EventArgs e)
        {
            if (MessageBox.Show("You don't have access to load this page.\nThe application will exit now.") == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        public void OnLoadSuccess(EventArgs e)
        {
            if (LoadSuccess != null)
                LoadSuccess(this, e);
        }

        public void OnLoadFailure(EventArgs e)
        {
            if (LoadFailed != null)
                LoadFailed(this, e);
        }
    }
}
