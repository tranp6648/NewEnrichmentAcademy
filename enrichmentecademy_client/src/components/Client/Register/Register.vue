<script setup>
import MenuClient from '../MenuClient/MenuClient.vue';
import Footer from '../Footer/Footer.vue';
import { AddAccount } from '@/components/Services/AccountService';
import Swal from 'sweetalert2';
</script>
<template>
    <div v-if="isLoading" class="fixed top-0 left-0 w-full h-full bg-gray-900 bg-opacity-50 flex justify-center items-center z-50">
      <div class="animate-spin rounded-full h-16 w-16 border-t-4 border-b-4 border-primary-600"></div>
    </div>
    <div id="page" class="site header-template-one-activate">
        <div class="elementor elementor-1245">
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-097ab1c elementor-section-full_width elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no">
                    <div
                        class="elementor-column elementor-col-100 elementor-top-column elementor-element elementor-element-66d859d">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-e55ffa5 elementor-widget elementor-widget-eduplscore_header_template_one">
                                <div class="elementor-widget-container">
                                    <div class="edupls-menu-wrapper">
                                        <MenuClient />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
        <div class="breadcroumb-area">
            <div class="container-1220">
                <div class="breadcroumn-contnt">
                    <h2 class="page-title">
                        Register
                    </h2>
                    <div class="bre-sub">
                        <span>
                            <a href="" class="home" style="display: inline-block;text-decoration: none;">
                                <span style="font-size: 16px;">edupls</span>
                            </a>
                        </span>
                        >
                        <span>
                            <span class="post post-page current-item" style="font-size: 16px;">Register</span>
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <main id="primary" class="site-main content-area" style="margin:120px 0 ;">
            <div class="container-1220 full-width">
                <div class="page-layout">
                    <div class="row">
                        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12" style="padding: 0 10px;">
                            <div class="all-posts-wrapper">
                                <div class="edupls-page-content">
                                    <div id="post-2029" class="post-2029 page type-page status-publish hentry">
                                        <div class="entry-content">
                                            <div id="tutor-registration-wrap">
                                                <div class="tabs">
                                                    <button :class="{ active: activeTab === 'student' }"
                                                        @click="activeTab = 'student'">Student</button>
                                                    <button :class="{ active: activeTab === 'teacher' }"
                                                        @click="activeTab = 'teacher'">Teacher</button>
                                                </div>
                                                <div v-if="activeTab === 'student'">
                                                    <div class="breadcroumn-contnt">
                                                        <h2 class="page-title"
                                                            style="color: black;text-align: center;margin-bottom: 12px">
                                                            Welcome Student</h2>

                                                    </div>
                                                    <form  id="tutor-registration-form" @submit.prevent="SubmitAccount('student')">
                                                        <div class="row">
                                                            <div class="col-md-6" style="padding: 0 10px;">
                                                                <div class="tutor-form-group">
                                                                    <label for="" style="font-size: 14px;">Name</label>
                                                                    <input type="text" placeholder="Name"
                                                                        class="tutorial" v-model="student.name"
                                                                        style="width: 100%;display: block;border: 1px solid #dcdfe5;box-shadow: none;margin-bottom: 20px;border-radius: 4px;background: #fff;line-height: 48px;padding: 0;text-indent: 15px;transition: 300ms;font-size: 16px;color: #626262;outline: none;">
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6" style="padding: 0 10px;">
                                                                <div class="tutor-form-group">
                                                                    <label for="" style="font-size: 14px;">Email</label>
                                                                    <input type="email" placeholder="Email"
                                                                        class="tutorial" v-model="student.email"
                                                                        style="width: 100%;display: block;border: 1px solid #dcdfe5;box-shadow: none;margin-bottom: 20px;border-radius: 4px;background: #fff;line-height: 48px;padding: 0;text-indent: 15px;transition: 300ms;font-size: 16px;color: #626262;outline: none;">
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12" style="padding: 0 10px;">
                                                                <div class="tutor-form-group">
                                                                    <label for="" style="font-size: 14px;">Birthday</label>
                                                                    <input type="date" placeholder="Birthday"
                                                                        class="tutorial"
                                                                        v-model="student.birthday"
                                                                        style="width: 100%;display: block;border: 1px solid #dcdfe5;box-shadow: none;margin-bottom: 20px;border-radius: 4px;background: #fff;line-height: 48px;padding: 0;text-indent: 15px;transition: 300ms;font-size: 16px;color: #626262;outline: none;">
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12" style="padding: 0 10px;">
                                                                <div class="tutor-form-group">
                                                                    <label for="" style="font-size: 14px;">Phone</label>
                                                                    <input type="tel" placeholder="Phone"
                                                                        class="tutorial"
                                                                        v-model="student.phone"
                                                                        style="width: 100%;display: block;border: 1px solid #dcdfe5;box-shadow: none;margin-bottom: 20px;border-radius: 4px;background: #fff;line-height: 48px;padding: 0;text-indent: 15px;transition: 300ms;font-size: 16px;color: #626262;outline: none;">
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12" style="padding: 0 10px;">
                                                                <button type="submit"
                                                                    class="tutor-btn tutor-btn-primary tutor-btn-block"
                                                                    style="width: 100%;display:flex;justify-content: center;outline: none;">Register</button>
                                                            </div>
                                                        </div>
                                                    </form>
                                                </div>
                                                <div v-if="activeTab === 'teacher'">
                                                    <div class="breadcroumn-contnt">
                                                        <h2 class="page-title"
                                                            style="color: black;text-align: center;margin-bottom: 12px">
                                                            Welcome Teacher</h2>

                                                    </div>
                                                    <form id="tutor-registration-form" @submit.prevent="SubmitAccount('teacher')">
                                                        <div class="row">
                                                            <div class="col-md-6" style="padding: 0 10px;">
                                                                <div class="tutor-form-group">
                                                                    <label for="" style="font-size: 14px;">Name</label>
                                                                    <input type="text" placeholder="Name"
                                                                        class="tutorial" v-model="teacher.name"
                                                                        style="width: 100%;display: block;border: 1px solid #dcdfe5;box-shadow: none;margin-bottom: 20px;border-radius: 4px;background: #fff;line-height: 48px;padding: 0;text-indent: 15px;transition: 300ms;font-size: 16px;color: #626262;outline: none;">
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6" style="padding: 0 10px;">
                                                                <div class="tutor-form-group">
                                                                    <label for="" style="font-size: 14px;">Email</label>
                                                                    <input type="email" placeholder="Email"
                                                                        class="tutorial" v-model="teacher.email"
                                                                        style="width: 100%;display: block;border: 1px solid #dcdfe5;box-shadow: none;margin-bottom: 20px;border-radius: 4px;background: #fff;line-height: 48px;padding: 0;text-indent: 15px;transition: 300ms;font-size: 16px;color: #626262;outline: none;">
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12" style="padding: 0 10px;">
                                                                <div class="tutor-form-group">
                                                                    <label for="" style="font-size: 14px;">Birthday</label>
                                                                    <input type="date" placeholder="Birthday"
                                                                        class="tutorial"
                                                                        v-model="teacher.birthday"
                                                                        style="width: 100%;display: block;border: 1px solid #dcdfe5;box-shadow: none;margin-bottom: 20px;border-radius: 4px;background: #fff;line-height: 48px;padding: 0;text-indent: 15px;transition: 300ms;font-size: 16px;color: #626262;outline: none;">
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12" style="padding: 0 10px;">
                                                                <div class="tutor-form-group">
                                                                    <label for="" style="font-size: 14px;">Phone</label>
                                                                    <input type="tel" placeholder="Phone"
                                                                        class="tutorial"
                                                                        v-model="teacher.phone"
                                                                        style="width: 100%;display: block;border: 1px solid #dcdfe5;box-shadow: none;margin-bottom: 20px;border-radius: 4px;background: #fff;line-height: 48px;padding: 0;text-indent: 15px;transition: 300ms;font-size: 16px;color: #626262;outline: none;">
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12" style="padding: 0 10px;">
                                                                <button type="submit"
                                                                    class="tutor-btn tutor-btn-primary tutor-btn-block"
                                                                    style="width: 100%;display:flex;justify-content: center;outline: none;">Register</button>
                                                            </div>
                                                        </div>
                                                    </form>
                                                </div>


                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
        <Footer />
    </div>
    <div class="to-top" id="back-top" @click="scrollToTop">
        <i class="fa-solid fa-arrow-up"></i>
    </div>
</template>
<style>
@import url('./Register.css');

.tutorial::placeholder {
    color: #626262;
    opacity: 0.5;
}

.tabs {
    display: flex;
    justify-content: center;
    margin-bottom: 20px;
}

.tabs button {
    padding: 10px 20px;
    border: none;
    font-size: 20px;
    background-color: #f1f1f1;
    cursor: pointer;
}

.tabs button.active {
    background-color: #007bff;
    color: white;
}
</style>
<script>
export default {
    data() {
        return {
            activeTab: 'student',
            student: {
                name: '',
                email: '',
                birthday: '',
                phone: '',
                accountType: 2
            },
            teacher: {
                name: '',
                email: '',
                birthday: '',
                phone: '',
                accountType: 1
            },
            isLoading:false,
        }
    },
    methods: {
        scrollToTop() {
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            })
        },
        async SubmitAccount(type){
            this.isLoading=true;
            try{
                const accountData=type==='student'?this.student:this.teacher;
                await AddAccount(accountData);
                this.resetForm(type);
                Swal.fire({
                    icon: 'success',
                    title: 'Add Brand Success',
                    showConfirmButton: false,
                    timer: 1500,
                });
            }catch(error){
                console.error('Error creating account:', error);
            }finally{
                this.isLoading=false;
            }
        },
        resetForm(type) {
            if (type === 'student') {
                this.student = {
                    name: '',
                    email: '',
                    birthday: '',
                    phone: '',
                    accountType: 2
                };
            } else {
                this.teacher = {
                    name: '',
                    email: '',
                    birthday: '',
                    phone: '',
                    accountType: 1
                };
            }
        }
    }
}
</script>
 <style>
@import url('./Register.css');
</style>