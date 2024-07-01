<script setup>
import { ref } from 'vue';
  import MenuClient from '../MenuClient/MenuClient.vue';
  import Footer from '../Footer/Footer.vue';
import Swal from 'sweetalert2';
import { ResetPassword } from '@/components/Services/AccountService';
import { useRoute, useRouter } from 'vue-router';
const route = useRoute();
const router = useRouter();
const email = route.params.email;
const ResetPasswordData = ref({
  NewPassword: '',
  ConfirmPass: '',
});
const handleResetPass = async () => {
if(ResetPasswordData.value.NewPassword=='' || ResetPasswordData.value.ConfirmPass==''){
    Swal.fire({
                    icon: 'error',
                    title: 'Password and Confirm Passsword is required',
                    showConfirmButton: false,
                    timer: 1500,
                });
}else if(ResetPasswordData.value.NewPassword.length<8 || ResetPasswordData.value.ConfirmPass.length<8){
    Swal.fire({
                    icon: 'error',
                    title: 'Password must be over 8 characters',
                    showConfirmButton: false,
                    timer: 1500,
                });
}else if(ResetPasswordData.value.NewPassword!=ResetPasswordData.value.ConfirmPass){
    Swal.fire({
                    icon: 'error',
                    title: 'password and confirm password must be the same',
                    showConfirmButton: false,
                    timer: 1500,
                });
}else{
    const response=await ResetPassword(email,ResetPasswordData.value.ConfirmPass);
    if(response){
        Swal.fire({
                    icon: 'success',
                    title: 'Reset Success',
                    showConfirmButton: false,
                    timer: 1500,
                }).then(() => {
      router.push({ 
        path: `/Login`, 
     
      });
    });
    }
}
}


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

        <form class="tutor-forgot-password-form tutor-ResetPassword lost_reset_password" @submit.prevent="handleResetPass"
       >
        
         
            <div class="row">
                <div class="col-md-12" style="padding: 0 10px;">
                    <div class="tutor-form-group">
                        <label for=""
                            style="display: block;margin-bottom: 10px;margin-top: -2px;font-size: 16px;color: #7b7e86;font-weight: 400;">Password</label>
                        <input type="password"  class="tutorial" v-model="ResetPasswordData.NewPassword"
                            style="width: 100%;display: block;border: 1px solid #dcdfe5;box-shadow: none;margin-bottom: 20px;border-radius: 4px;background: #fff;line-height: 48px;padding: 0;text-indent: 15px;transition: 300ms;font-size: 16px;color: #626262;outline: none;">
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-12" style="padding: 0 10px;">
                    <div class="tutor-form-group">
                        <label for=""
                            style="display: block;margin-bottom: 10px;margin-top: -2px;font-size: 16px;color: #7b7e86;font-weight: 400;">Confirm Password</label>
                        <input type="password"  class="tutorial"v-model="ResetPasswordData.ConfirmPass"
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
