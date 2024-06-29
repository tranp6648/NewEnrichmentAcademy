<script setup>
  import layout from '../layout/layout.vue';

</script>
<template>
  <div class="skin-blue wysihtml5-supported">
    <div class="wrapper">
      <layout />
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
          Manager Teacher
            <small>advanced tables</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#">Tables</a></li>
            <li class="active">Data tables</li>
          </ol>
        </section>

        <!-- Main content -->
        <section class="content">
          <div class="row">
            <div class="col-xs-12">
             
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">Teacher</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                  <table id="example1" class="table table-bordered table-hover">
                    <thead>
                     <tr>
                      <th>#</th>
                      <th>Name</th>
                      <th>Email</th>
                      <th>Birthday</th>
                      <th>Phone</th>
                     </tr>
                    </thead>
                    <tbody>
                      <tr v-for="(account,index) in accounts" :key="account.id">
                        <td>{{index+1}}</td>
                        <td>{{account.name}}</td>
                        <td>{{account.email}}</td>
                        <td>{{formatDate(account.birthday)}}</td>
                        <td>{{account.phone}}</td>
                        <td></td>
                      </tr>
                    </tbody>
                  </table>
                </div><!-- /.box-body -->
              </div><!-- /.box -->
            </div><!-- /.col -->
          </div><!-- /.row -->
        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->
      <footer class="main-footer">
        <div class="pull-right hidden-xs">
          <b>Version</b> 2.0
        </div>
        <strong>Copyright &copy; 2014-2015 <a href="http://almsaeedstudio.com">Almsaeed Studio</a>.</strong> All rights
        reserved.
      </footer>
    </div>
  </div>
</template>
<script>
  import { ref } from 'vue';
  import { ShowAccount } from '../../Services/AccountService';
  import Swal from 'sweetalert2';
  export default {
    data() {
      return {
      accounts:[]
      }
    },
    async mounted(){
      try{
        const data=await ShowAccount();
        this.accounts=data;
      }catch(error){
        console.error('Error fetching accounts:', error);
      }
    },
    methods: {
      formatDate(dateString) {
      return new Date(dateString).toLocaleString('en-GB', {
        day: 'numeric',
        month: 'short',
        year: 'numeric'
      });
    }
    }


  }
</script>