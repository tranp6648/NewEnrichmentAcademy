<script setup>
import MenuClient from '../MenuClient/MenuClient.vue';
import Footer from '../Footer/Footer.vue';
import { ForgetPassword } from '@/components/Services/AccountService';
import Swal from 'sweetalert2';
</script>
<template>

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

        <form class="tutor-forgot-password-form tutor-ResetPassword lost_reset_password"
        @submit.prevent="handleForgetPassword">
        
            <p style="font-size: 16px;line-height: 26px;color: #7b7e86;">Lost your password? Please enter your username
                or email address. You will receive a link to create a new password via email.</p>
            <div class="row">
                <div class="col-md-12" style="padding: 0 10px;">
                    <div class="tutor-form-group">
                        <label for=""
                            style="display: block;margin-bottom: 10px;margin-top: -2px;font-size: 16px;color: #7b7e86;font-weight: 400;">Username
                            or email</label>
                        <input type="email" placeholder="Email Address" class="tutorial" v-model="ForgetPass.email"
                            style="width: 100%;display: block;border: 1px solid #dcdfe5;box-shadow: none;margin-bottom: 20px;border-radius: 4px;background: #fff;line-height: 48px;padding: 0;text-indent: 15px;transition: 300ms;font-size: 16px;color: #626262;outline: none;">
                    </div>
                </div>

            </div>
            <div class="tutor-d-flex tutor-justify-between tutor-align-center tutor-mb-40"
                style="display: flex;justify-content: flex-start;margin-bottom: 40px">
                <button type="submit" class="tutor-btn tutor-btn-ghost">

                    Reset password </button>
            </div>


        </form>
        <Footer />
    </div>

</template>
<style>
@import url('./Forget.css');
</style>
<script>
export default {
    data() {
        return {
            ForgetPass: {
                email: ''
            },
            isLoading: false,
            IsSuccess: false,
        }
    },

methods: {
   
    async handleForgetPassword() {
      this.isLoading = true;
      
      try {
        console.log(this.ForgetPass.email)
        const response = await ForgetPassword(this.ForgetPass.email);
        if (response) {
       
            Swal.fire({
                    icon: 'success',
                    title: 'Request Reset success',
                    showConfirmButton: false,
                    timer: 1500,
                }).then(() => {
                    this.$router.push({ path: `/OTP/${this.ForgetPass.email}` });
                })
        
        }
      } catch (error) {
        console.error('Error during password reset:', error);
      } finally {
        this.isLoading = false;
      }
    }

}
}

</script>