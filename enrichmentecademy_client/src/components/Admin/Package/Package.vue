<script setup>
    import { AddPackage, GetSubject } from '@/components/Services/PackageService';
import layout from '../layout/layout.vue';
import Swal from 'sweetalert2';
</script>
<template>
    <div class="skin-blue wysihtml5-supported">
        <div class="wrapper">
            <layout />
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>
                        Manager Package
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
                        <div class="box box-info">
                            <div class="box-header">
                                <h3 class="box-title">Package</h3>
                            </div>
                            <div class="box-body">
                                <form @submit.prevent="HandleCreatPackage">
                                    <div class="form-group">
                                        <label>Name:</label>
                                        <input type="text" class="form-control my-colorpicker1" placeholder="Name" v-model="FromData.Name"
                                           style="font-size: 15px;" />
                                    </div>
                                    <div class="form-group">
                                        <label>Price:</label>
                                        <input type="number" class="form-control my-colorpicker1" placeholder="Price"
                                          style="font-size: 15px;" v-model="FromData.Price" />
                                    </div>
                                
                                    <div class="form-group">
                                        <label>Subject:</label>
                                        <select class="form-select" aria-label="Default select example"
                                           style="font-size: 15px;width:100%" v-model="FromData.IdSubject" multiple >
                                            <option v-for="Subject in Subjects" :key="Subject.id" :value="Subject.id">{{
                                                Subject.name }}</option>

                                        </select>
                                    </div>

                                    <button type="submit" class="btn btn-primary me-2 py-[0.8rem] px-4"
                                        style="font-size: 15px;">Submit</button>
                                </form>






                                <!-- time Picker -->

                            </div><!-- /.box-body -->
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">

                            <div class="box">
                                <div class="box-header">
                                    <h3 class="box-title">Subject</h3>
                                </div><!-- /.box-header -->
                                <form class="forms-sample">
                                    <label for="exampleInputUsername1">Search</label>
                                    <input type="text" class="form-control" id="exampleInputUsername1"
                                        placeholder="Enter Name" v-model="SearchQuery" />
                                </form>
                                <div class="box-body">
                                    <table id="example1" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Name</th>
                                                <th>Faculty</th>
                                                <th>Image</th>
                                                <th>Edit</th>
                                                <th>Remove</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            
                                        </tbody>
                                    </table>
                                
                                </div>
                            </div><!-- /.box -->
                        </div><!-- /.col -->
                    </div><!-- /.row -->
                </section><!-- /.content -->
            </div><!-- /.content-wrapper -->
            <footer class="main-footer">
                <div class="pull-right hidden-xs">
                    <b>Version</b> 2.0
                </div>
                <strong>Copyright &copy; 2014-2015 <a href="http://almsaeedstudio.com">Almsaeed Studio</a>.</strong> All
                rights
                reserved.
            </footer>
        </div>
    </div>

</template>
<script>
export default {
    data(){
        return{
            Subjects:[],
            FromData:{
                Name:'',
                Price:'',
                IdSubject:[]
            }
        }
    },
    async mounted() {
        try{
            const data=await GetSubject();
            this.Subjects=data;
        }catch(error){
            console.log(error)
        }
    },
    methods:{
        async HandleCreatPackage(){
            try{
                const respose=await AddPackage({
                    name:this.FromData.Name,
                    pricePackage:this.FromData.Price,
                    idSubject:this.FromData.IdSubject
                })
                console.log(respose)
                if(respose){
                    Swal.fire({
                            icon: 'success',
                            title: 'Add Package Success',
                            showConfirmButton: false,
                            timer: 1500,
                        });
                }
                this.FromData={
                    Name:'',
                Price:'',
                IdSubject:[]
                }
            }catch(error){
                console.log(error)
            }
        }
    }
}
</script>