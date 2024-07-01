<script setup>
  import { ref, computed, watch } from 'vue';
  import MenuClient from '../MenuClient/MenuClient.vue';
  import Footer from '../Footer/Footer.vue';
  import { useRoute,useRouter } from 'vue-router';
  import { CheckOTP } from '@/components/Services/AccountService';
  import Swal from 'sweetalert2';
  const otp = ref(['', '', '', '']);
  const concatenatedOtpString = ref('');
  const route = useRoute();
  const router=useRouter();
  const email = route.params.email;

  const otpInputStyle = {
    width: '100%',
    display: 'block',
    border: '1px solid #dcdfe5',
    boxShadow: 'none',
    marginBottom: '20px',
    borderRadius: '4px',
    background: '#fff',
    lineHeight: '48px',
    padding: '0',
    textIndent: '15px',
    transition: '300ms',
    fontSize: '16px',
    color: '#626262',
    outline: 'none',
    textAlign: 'center'
  };
  const handleKeyDown = (event, index) => {
    if (event.key === 'Backspace' && index > 0 && otp.value[index] === '') {

      const prevInput = document.getElementById('otpInput' + (index - 1));
      if (prevInput) {
        prevInput.focus();
      }
    }
  };
  const HanleCheckOTP = async () => {
    try {
      const response = await CheckOTP(email, concatenatedOtpString.value);
      if (response) {
        Swal.fire({
          icon: 'success',
          title: 'Verify success',
          showConfirmButton: false,
          timer: 1500,
        }).then(() => {
      router.push({ 
        path: `/RetriPassword/${email}`, 
        state: { sessionData: { email } } 
      });
    });
  }
    } catch (error) {
      console.log(error)
    }
  }
  const handleInput = (event, index) => {
    // Ensure input is a single digit

    const input = event.data;

    if (!/^\d$/.test(input)) {

      otp.value[index] = '';
      return;
    }
    const nextInput = document.getElementById('otpInput' + (index + 1));

    if (nextInput) {
      nextInput.focus();
    }
    const concatenatedOtp = computed(() => otp.value.join(''));
    watch(concatenatedOtp, (newVal) => {

      concatenatedOtpString.value = newVal;  // Update the variable with the concatenated string
    });


  };

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

    <form class="tutor-forgot-password-form tutor-ResetPassword lost_reset_password" @submit.prevent="HanleCheckOTP">


      <div class="row otp-inputs">
        <div class="col-md-3" v-for="(digit, index) in otp" :key="index" style="padding: 0 10px;">
          <div class="tutor-form-group">
            <input type="text" maxlength="1" class="otp-input" v-model="otp[index]" @input="handleInput($event, index)"
              @keydown="handleKeyDown($event, index)" :style="otpInputStyle" ref="otpInputs" :id="'otpInput' + index"
              :ref="'otpInput' + index" />
          </div>
        </div>
      </div>
      <div class="tutor-d-flex tutor-justify-between tutor-align-center tutor-mb-40"
        style="display: flex;justify-content: flex-start;margin-bottom: 40px">
        <button type="submit" class="tutor-btn tutor-btn-ghost">

          Verify </button>
      </div>


    </form>
    <Footer />
  </div>

</template>