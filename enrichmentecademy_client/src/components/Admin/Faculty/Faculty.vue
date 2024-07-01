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
                        Manager Faculty
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
                                <h3 class="box-title">Faculty</h3>
                            </div>
                            <div class="box-body">
                                <form @submit.prevent="HandleCreateFaculty">
                                    <div class="form-group">
                                        <label>Name:</label>
                                        <input type="text" class="form-control my-colorpicker1" style="font-size: 15px;"
                                            v-model="Faculty.name" />
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
                                    <h3 class="box-title">Faculty</h3>
                                </div><!-- /.box-header -->
                                <form class="forms-sample">
                                    <label for="exampleInputUsername1">Search</label>
                                    <input type="text" class="form-control" id="exampleInputUsername1"
                                        placeholder="Enter Name" v-model="searchQuery" />
                                </form>
                                <div class="box-body">
                                    <table id="example1" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Name</th>
                                                <th>Edit</th>
                                                <th>Remove</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr v-for="(facul,index) in PaginatedAccounts" :key="facul.id">
                                                <td>{{ index+1 }}</td>
                                                <td>{{ facul.name }}</td>
                                                <td><button
                                                        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-[0.8rem] px-4 rounded "
                                                        @click="HandleEditClick(facul.id)">Edit</button></td>
                                                        <td><button @click="HandleRemove(facul.id)" className="bg-red-500 hover:bg-red-700 text-white font-bold py-[0.8rem] px-4 rounded ">Delete</button></td>
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
            <div className='flex justify-end'>
                <button @click="handleClosePopup"
                    className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded float-right "><i
                        className="fas fa-times"></i></button>
            </div>
            <div style="margin-top: 16px;">

                <h3 className="box-title1">Edit Facuties</h3>
            </div>
            <form @submit.prevent="HandleUpdateFaculty">
                <div class="box-body">
                    <div class="form-group">
                        <label class="float-left">Name</label>
                        <input type="text" class="form-control" v-model="FromData.UpdateName" placeholder=" Name">
                    </div>
                </div>
                <div class="box-footer">
            <button
              class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-[0.8rem] px-4 rounded"
            >
              Update
            </button>
          </div>
            </form>
        </div>
    </div>
</template>
<script>
    import { CreateFaculty, GetFaculty, UpdateFaculty,DeleteFaculty } from '@/components/Services/FacultyService';
    import Swal from 'sweetalert2';
    export default {
        data() {
            return {
                searchQuery: '',
                PopupVisibility: false,
                IsClosingPopup: false,
                Facuties: [],
                Faculty: {
                    name: ''
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
                FromData: {
                    UpdateName: '',
                    id: '',
                },
                closingAnimation: {
                    animation: 'flipright 0.5s forwards',
                },
                currentPage: 1,
                perPage: 5
            }
        },
        async mounted() {
            try {
                const data = await GetFaculty();
                this.Facuties = data;
            } catch (error) {
                console.error('Error fetching accounts:', error);
            }
        },
        computed: {
            filtedFaculty() {
                return this.Facuties.filter(account => account.name.toLowerCase().includes(this.searchQuery.toLowerCase()))
            },
            PaginatedAccounts() {
                const start = (this.currentPage - 1) * this.perPage;
                const end = start + this.perPage;
                return this.filtedFaculty.slice(start, end);
            },
            totalPages() {
                return Math.ceil(this.filtedFaculty.length / this.perPage);
            }
        },
        methods: {
            async HandleUpdateFaculty() {
                try {
                    console.log(this.FromData.id)
                    const response = await UpdateFaculty(this.FromData.id, {
                        name: this.FromData.UpdateName
                    });
                    
                    if (!response.message) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Update Faculty Success',
                            showConfirmButton: false,
                            timer: 1500,
                        });
                        this.FromData = {
                            UpdateName: '',
                            id: '',
                        }
                        await this.fetchdata();
                        this.PopupVisibility = false;
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
            },
            async HandleRemove(Id){
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
                const response=await DeleteFaculty(Id);
               
                if(response){
                    Swal.fire({
                        icon: 'success',
                        title: 'Deletion successful',
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
            HandleEditClick(IdFaculiti) {
                
                const SelectFaculty = this.Facuties.find(facul => facul.id == IdFaculiti);
               
                if (SelectFaculty) {
                    this.FromData.UpdateName = SelectFaculty.name;
                    this.FromData.id = IdFaculiti;
                }
                this.PopupVisibility = true;
            },
            handleClosePopup() {
                this.IsClosingPopup = true;
                setTimeout(() => {
                    this.PopupVisibility = false;
                    this.IsClosingPopup = false;
                }, 500);
            },
            async fetchdata() {
                try {
                    const data = await GetFaculty();
                    this.Facuties = data;
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
            async HandleCreateFaculty() {
                try {
                    const response = await CreateFaculty(this.Faculty);
                    if (!response.message) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Create Faculty success',
                            showConfirmButton: false,
                            timer: 1500,
                        })
                        await this.fetchdata();
                        this.Faculty = {
                            name: ''
                        }

                    } else {
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
        },
        mounted() {
            this.fetchdata();
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

    .popup-container {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background: rgba(0, 0, 0, 0.4);
        /* White background with some transparency */
        display: flex;
        justify-content: center;
        align-items: center;
        opacity: 1;
        z-index: 1000;
        transition: all ease 2.5s;

    }

    .popup-content {
        background: #FDFCF0;
        padding: 20px;
        max-width: 400px;
        text-align: center;
        border-radius: 8px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        animation: flipleft 0.5s;

    }

    @keyframes flipleft {
        from {
            transform: perspective(400px) rotateY(90deg);
            opacity: 0;
        }

        to {
            transform: perspective(400px) rotateY(0deg);
            opacity: 1;
        }
    }

    @keyframes flipright {
        from {
            transform: perspective(400px) rotateY(0deg);
            opacity: 1;
        }

        to {

            transform: perspective(400px) rotateY(90deg);
            opacity: 0;
        }
    }
</style>