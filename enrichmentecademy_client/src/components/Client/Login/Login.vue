<script setup>
import MenuClient from '../MenuClient/MenuClient.vue';
import Footer from '../Footer/Footer.vue';
import Swal from 'sweetalert2';
import { LoginAccount } from '@/components/Services/AccountService';
import Cookies from 'js-cookie';
import { useRouter } from 'vue-router';

</script>
<template>
    <div v-if="isloading"
        class="fixed top-0 left-0 w-full h-full bg-gray-900 bg-opacity-50 flex justify-center items-center z-50">
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
                        Login
                    </h2>
                    <div class="bre-sub">
                        <span>
                            <a href="" class="home" style="display: inline-block;text-decoration: none;">
                                <span style="font-size: 16px;">edupls</span>
                            </a>
                        </span>
                        >
                        <span>
                            <span class="post post-page current-item" style="font-size: 16px;">Login</span>
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
                                                <form id="tutor-registration-form" @submit.prevent="handleLogin">
                                                    <div class="tutor-fs-5 tutor-color-black tutor-mb-32"
                                                        style="color: #1C1C1C;font-size: 20px;margin-bottom: 10px">

                                                        Hi, Welcome back!
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12" style="padding: 0 10px;">
                                                            <div class="tutor-form-group">

                                                                <input type="email" placeholder="Email Address"
                                                                    class="tutorial" v-model="formData.email"
                                                                    style="width: 100%;display: block;border: 1px solid #dcdfe5;box-shadow: none;margin-bottom: 20px;border-radius: 4px;background: #fff;line-height: 48px;padding: 0;text-indent: 15px;transition: 300ms;font-size: 16px;color: #626262;outline: none;">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12" style="padding: 0 10px;">
                                                            <div class="tutor-form-group">

                                                                <input type="password" placeholder="Password"
                                                                    class="tutorial" v-model="formData.password"
                                                                    style="width: 100%;display: block;border: 1px solid #dcdfe5;box-shadow: none;margin-bottom: 20px;border-radius: 4px;background: #fff;line-height: 48px;padding: 0;text-indent: 15px;transition: 300ms;font-size: 16px;color: #626262;outline: none;">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="tutor-d-flex tutor-justify-between tutor-align-center tutor-mb-40"
                                                        style="display: flex;justify-content: flex-end;">
                                                        <router-link href="" to="/Forget" class="tutor-btn tutor-btn-ghost">
                                                            Forgot? </router-link>
                                                    </div>
                                                    <button type="submit"
                                                        class="tutor-btn tutor-btn-primary tutor-btn-block"
                                                        style="width: 100%;margin-top: 12px;display: flex;justify-content: center;">

                                                        Sign In
                                                    </button>
                                                    <div class="tutor-text-center tutor-fs-6 tutor-color-secondary tutor-mt-20"
                                                        style="font-size: 16px;display: flex;justify-content: center;align-items: center;margin-top: 12px">

                                                        Don't have an account? &nbsp;
                                                        <a href="" style="color: #179BD7;background: transparent;">
                                                            Register Now </a>
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
        </main>
        <Footer />
    </div>
    <div class="to-top" id="back-top" @click="scrollToTop">
        <i class="fa-solid fa-arrow-up"></i>
    </div>
</template>
<script>
export default {
    data() {
        return {
            formData: {
                email: '',
                password: '',
            },
            isloading: false,
        }
    },
 
    methods: {
        scrollToTop() {
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            })
        },
        async handleLogin() {
            this.isloading = true;
            try {
                const response = await LoginAccount(this.formData.email, this.formData.password);
                const responsedata = response;
                const { id, name, email, birthday, phone, accountype } = responsedata;
                console.log(accountype)
                const sessionData = {
                    ID: id,
                    name: name,
                    email: email,
                    birthday: birthday,
                    phone: phone,
                    accountType: accountype
                }
                Cookies.set('UserSession', JSON.stringify(sessionData), { expires: 0.5, secure: true, sameSite: 'strict' });

                Swal.fire({
                    icon: 'success',
                    title: 'Login success',
                    showConfirmButton: false,
                    timer: 1500,
                }).then(() => {


                    this.$router.push({ name: 'Admin', state: sessionData })

                })

            } catch (error) {
                this.isLoading = false;
                Swal.fire({
                    icon: 'error',
                    title: 'Login Failed',
                    showConfirmButton: false,
                    timer: 1500,
                });
            } finally {
                this.isloading = false;
            }
        }
    }
}
</script>
