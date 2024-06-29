<template>
    <header class="main-header" style="max-height: 54px;">
        <!-- Logo -->
        <a href="index2.html" class="logo"><b>Admin</b>LTE</a>
        <!-- Header Navbar: style can be found in header.less -->
        <nav class="navbar navbar-static-top" role="navigation" style="max-height: 50px;">
          <!-- Sidebar toggle button-->
          <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
            <span class="sr-only">Toggle navigation</span>
          </a>
          <div class="navbar-custom-menu">
       
          </div>
        </nav>
      </header>
      <aside class="main-sidebar">
        <!-- sidebar: style can be found in sidebar.less -->
        <section class="sidebar" style="background: #222d32;">
          <!-- Sidebar user panel -->
          <div class="user-panel">
            <div class="pull-left image">
              <img src="" class="img-circle" alt="User Image" />
            </div>
            <div class="pull-left info">
              <p>Alexander Pierce</p>

              <a href="#"><i class="fa fa-circle text-success"></i> Online</a>
            </div>
          </div>
          <!-- search form -->
          <form action="#" method="get" class="sidebar-form">
            <div class="input-group" style="position: relative;display: table;border-collapse: separate">
              <input type="text" name="q" class="form-control" placeholder="Search..." style="width: 100%;"/>
              <span class="input-group-btn">
                <button type='submit' name='search' id='search-btn' class="btn btn-flat"><i class="fa fa-search"></i></button>
              </span>
            </div>
          </form>
          <!-- /.search form -->
          <!-- sidebar menu: : style can be found in sidebar.less -->
          <ul class="sidebar-menu">
            <li class="header">MAIN NAVIGATION</li>
            <li class="active treeview">
              <a href="#">
                <i class="fa fa-dashboard"></i> <span>Dashboard</span> 
              </a>
     
            </li>
            <li class="active treeview">
              <router-link to="/CreateAcc" >
                <i class="fa fa-dashboard"></i> <span>Teacher</span> 
              </router-link>
     
            </li>
  
        
        
          

            <li class="header">LABELS</li>
            <li><a href="#"><i class="fa fa-circle-o text-danger"></i> Important</a></li>
            <li><a href="#"><i class="fa fa-circle-o text-warning"></i> Warning</a></li>
            <li><a href="#"><i class="fa fa-circle-o text-info"></i> Information</a></li>
          </ul>
        </section>

      </aside>

</template>
<style>
    @import url('../assets/bootstrap/css/bootstrap.min.css');
    @import url('../assets/dist/css/AdminLTE.min.css');
    @import url('../assets/dist/css/skins/_all-skins.min.css');
    @import url('../assets/plugins/iCheck/flat/blue.css');
    @import url('../assets/plugins/morris/morris.css');
    @import url('../assets/plugins/jvectormap/jquery-jvectormap-1.2.2.css');
    @import url('../assets/plugins/datepicker/datepicker3.css');
    @import url('../assets/plugins/daterangepicker/daterangepicker-bs3.css');
    @import url('../assets/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css');
    a{
  text-decoration: none !important;
}
</style>