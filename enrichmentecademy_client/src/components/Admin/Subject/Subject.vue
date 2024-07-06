<script setup>
    import { CreateSubject, DeleteSubject, GetSubject, ShowFaculty, UpdateSubject } from '@/components/Services/SubjectService';
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
                        Manager Subject
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
                                <h3 class="box-title">Subject</h3>
                            </div>
                            <div class="box-body">
                                <form @submit.prevent="AddSubject">
                                    <div class="form-group">
                                        <label>Name:</label>
                                        <input type="text" class="form-control my-colorpicker1" placeholder="Name"
                                            v-model="FromData.Name" style="font-size: 15px;" />
                                    </div>
                                    <div class="form-group">
                                        <label>Price:</label>
                                        <input type="number" class="form-control my-colorpicker1" placeholder="Price"
                                            v-model="FromData.Price" style="font-size: 15px;" />
                                    </div>
                                    <div class="form-group">
                                        <label>Photo:</label>
                                        <input type="file" @change="handleFilechange"
                                            class="form-control my-colorpicker1" id="Photo" style="font-size: 15px;" />
                                            <div v-if="ImagePreView" className="image-preview">
                                                        <img :src="ImagePreView" alt="Preview" className="preview-image" />
                                                    </div>
                                    </div>
                                    <div class="form-group">
                                        <label>Faculty:</label>
                                        <select class="form-select" aria-label="Default select example"
                                            v-model="FromData.Idfaculties" style="font-size: 15px;width:100%">
                                            <option v-for="faculty in Facuties" :key="faculty.id" :value="faculty.id">{{
                                                faculty.name }}</option>

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
                                            <tr v-for="(subject,index) in PaginatedAccounts" :key="subject.id">
                                                <td>{{ index+1 }}</td>
                                                <td>{{ subject.name }}</td>
                                                <td>{{ subject.faculty }}</td>
                                                <td>
                                                    <img :src="subject.photo" width="500" height="500"
                                                        :style="{ objectFit: 'cover', borderRadius: '0%' }"
                                                        alt="Subject Image" />
                                                </td>
                                                <td><button
                                                        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-[0.8rem] px-4 rounded "
                                                        style="font-size: 15px;"
                                                        @click="handleEditClick(subject.id)">Edit</button></td>
                                                <td><button
                                                        className="bg-red-500 hover:bg-red-700 text-white font-bold py-[0.8rem] px-4 rounded " @click="HandleDeleteSubject(subject.id)"
                                                        style="font-size: 15px;">Delete</button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="pagination" style="display: flex;justify-content: flex-start;">
                                        <button @click="prevPage" :disabled="currentPage === 1">Previous</button>
                                        <button v-for="page in totalPages" :key="page" @click="setPage(page)"
                                            :class="{ active: page === currentPage }">{{ page }}</button>
                                        <button @click="nextPage" :disabled="currentPage === totalPages">Next</button>
                                    </div>
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
    <div v-if="PopupVisibility" class="popup-container">
        <div class="popup-content"
            :style="IsClosingPopup? {...popupContentStyle,...closingAnimation}:popupContentStyle">
            <div class="flex justify-end">
                <button @click="handleClosePopup" className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded float-right "><i
                        className="fas fa-times"></i></button>
            </div>
            <div style="margin-top: 16px;">

                <h3 className="box-title1">Edit Subject</h3>
            </div>
            <form @submit.prevent="HandleSubject">
                <div class="box-body">
                    <div class="form-group">
                        <label class="float-left">Name</label>
                        <input type="text" class="form-control" v-model="FromData.UpdateName" placeholder=" Name">
                    </div>
                    <div class="form-group">
                        <label class="float-left">Price</label>
                        <input type="text" class="form-control" v-model="FromData.UpdatePrice" placeholder=" Name">
                    </div>
                    <div class="form-group">
                                        <label class="float-left">Faculty:</label>
                                        <select class="form-select" aria-label="Default select example"
                                            v-model="FromData.UpdateIdFaculties" style="font-size: 15px;width:100%">
                                            <option v-for="faculty in Facuties" :key="faculty.id" :value="faculty.id">{{
                                                faculty.name }}</option>

                                        </select>
                                    </div>
                </div>
                <div class="box-footer">
                    <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-[0.8rem] px-4 rounded" >
                        Update
                    </button>
                </div>
            </form>
        </div>
    </div>
</template>
<script>
    import Multiselect from 'vue-multiselect';
    import Swal from 'sweetalert2';

    export default {
        components: {
            Multiselect,
        },
        data() {
            return {
                SearchQuery: '',
                PopupVisibility: false,
                IsClosingPopup: false,
                currentPage: 1,
                perPage: 5,
                FromData: {
                    id:'',
                    Name: '',
                    Price: '',
                    Idfaculties: null,
                    UpdateName: '',
                    UpdatePrice: '',
                    UpdateIdFaculties: null,
                },
                popupContentStyle: {
                    background: 'white',
                    padding: '20px',
                    maxWidth: '400px',
                    textAlign: 'center',
                    borderRadius: '8px',
                    boxShadow: '0 0 10px rgba(0, 0, 0, 0.1)',
                    animation: 'flipleft 0.5s',
                    zIndex: '1000000',
                },
                closingAnimation: {
                    animation: 'flipright 0.5s forwards',
                },
                Facuties: [],
                Subjects: [],
                SelectedFile: null,
                ImagePreView: null,

            }
        },
        async mounted() {
            try {
                const data = await ShowFaculty();
                const dataSubject = await GetSubject();
                this.Facuties = data;
                this.Subjects = dataSubject;
            } catch (error) {
                console.error('Error fetching accounts:', error);
            }
        },
        computed: {
            filterSubject() {
                return this.Subjects.filter(acc => acc.name.toLowerCase().includes(this.SearchQuery.toLowerCase())
                );
            },
            PaginatedAccounts() {
                const start = (this.currentPage - 1) * this.perPage;
                const end = start + this.perPage;
                return this.filterSubject.slice(start, end);
            },
            totalPages() {
                return Math.ceil(this.filterSubject.length / this.perPage);
            }
        },
        methods: {
            handleFilechange(event) {
            const file = event.target.files[0];

                if(file){
                    const reader=new FileReader();
                    reader.onloadend=()=>{
                        this.ImagePreView=reader.result;
                    }
                    reader.readAsDataURL(file);
                    this.SelectedFile=file;
                }

            },
            handleEditClick(idsubject) {
                const SelectSubject = this.Subjects.find(sub => sub.id == idsubject);
                if (SelectSubject) {
                    this.FromData.id=idsubject;
                    this.FromData.UpdateName = SelectSubject.name;
                    this.FromData.UpdatePrice = SelectSubject.price;
                    this.FromData.UpdateIdFaculties = SelectSubject.idFaculty;
                }
                this.PopupVisibility = true;
            },
            async fetchdata() {
                try {
                    const data = await GetSubject();
                    this.Subjects = data;
                } catch (error) {
                    console.error('Error fetching accounts:', error);
                }
            },
            setPage(page) {
                this.currentPage = page;
            },
            prevPage() {
                if (this.currentPage > 1) {
                    this.currentPage--;
                }
            },
            nextPage() {
                if (this.currentPage < this.totalPages) {
                    this.currentPage++;
                }
            },
            handleClosePopup() {
                this.IsClosingPopup = true;
                setTimeout(() => {
                    this.PopupVisibility = false;
                    this.IsClosingPopup = false;
                }, 500);
            },
            async HandleSubject(){
                if(this.FromData.UpdateName=='' || this.FromData.UpdateIdFaculties=='' || this.FromData.UpdatePrice==''){
                    Swal.fire({
                                icon: 'error',
                             title: 'Please enter complete information',
                                showConfirmButton: false,
                                timer: 1500,
                            });
                }else{
                    try{
                    const response=await UpdateSubject(this.FromData.id,{
                        name:this.FromData.UpdateName,
                        idFaculty:this.FromData.UpdateIdFaculties,
                        Price:this.FromData.UpdatePrice
                    })
                    if(!response.message){
                        Swal.fire({
                            icon: 'success',
                            title: 'Update Subject Success',
                            showConfirmButton: false,
                            timer: 1500,
                        });
                        this.FromData={
                            UpdateName: '',
                    UpdatePrice: '',
                    UpdateIdFaculties: null,
                        }
                     
                        await this.fetchdata();
                        this.PopupVisibility=false;

                    }else{
                        if (response.message) {
                            Swal.fire({
                                icon: 'error',
                                title: response.message || 'Failed to add genre',
                                showConfirmButton: false,
                                timer: 1500,
                            });
                        }
                    }
                }catch(error){
                    console.log(error)
                }
                }
             
            },
            async HandleDeleteSubject(Id){
                try{
                    const confirmation = await Swal.fire({
                title: 'Are you sure?',
                text: 'You won\'t be able to revert this!',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, Delete it',
            });
            if(confirmation.isConfirmed){
                const response=await DeleteSubject(Id);
                    if(response){
                        Swal.fire({
                            icon: 'success',
                            title: 'Delete Subject Success',
                            showConfirmButton: false,
                            timer: 1500,
                        });
                        await this.fetchdata();
                    }
            }
                    
                }catch(error){
                    console.log(error)
                }
            },
            async AddSubject() {
            
            if(this.FromData.Name=='' || this.SelectedFile==null || this.FromData.Idfaculties=='' || this.FromData.Price==''){
                Swal.fire({
                            icon: 'error',
                            title: 'Please enter complete information',
                            showConfirmButton: false,
                            timer: 1500,
                        });
            }else{
                try {
                    const formData = new FormData();
                    formData.append("Name", this.FromData.Name);
                    formData.append("LinkSubject", this.SelectedFile);
                    formData.append("IdFaculty", this.FromData.Idfaculties);
                    formData.append("Price", this.FromData.Price)
                    const response = await CreateSubject(formData);

                    if (!response.message) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Create Subject Success',
                            showConfirmButton: false,
                            timer: 1500,
                        });
                        this.FromData = {
                            Name: '',
                            Price: '',
                            Idfaculties: null,
                        }
                        this.ImagePreView=null;
                        this.SelectedFile = null;
                        document.getElementById('Photo').value = '';
                        await this.fetchdata();
                    }else{
                        if (response.message) {
                            Swal.fire({
                                icon: 'error',
                                title: response.message || 'Failed to add genre',
                                showConfirmButton: false,
                                timer: 1500,
                            });
                        }
                    }

                } catch (error) {
                    console.log(error)
                }
            }
              
            }

        }
    }
</script>
<style>
    .pagination {
        display: flex;
        justify-content: center;
        margin-top: 1rem;
    }

    .pagination button {
        margin: 0 0.25rem;
        padding: 0.5rem 1rem;
        border: none;
        background: #007bff;
        color: white;
        cursor: pointer;
    }

    .pagination button[disabled] {
        background: #cccccc;
        cursor: not-allowed;
    }

    .pagination button.active {
        background: #0056b3;
    }

    .form-select {
        appearance: none;
        -webkit-appearance: none;
        -moz-appearance: none;
        background-color: #f1f1f1;
        padding: 10px;
        border: 1px solid #ccc;
        border-radius: 4px;
        width: 200px;
        /* Điều chỉnh độ rộng tùy theo nhu cầu */
        font-size: 16px;
        cursor: pointer;
    }

    /* Định dạng cho option trong select */
    .form-select option {
        background-color: #fff;
        color: #333;
        font-size: 16px;
    }
</style>