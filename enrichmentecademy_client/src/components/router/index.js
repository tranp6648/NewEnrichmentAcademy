import { createRouter,createWebHistory } from "vue-router";
import HelloWord from '../Client/Homepage/HomePage.vue';
import HomeAdmin from '../Admin/HomePage/HomePage.vue';
import CreateAccount from '../Admin/Account/CreateAccount.vue';
import Register from '../Client/Register/Register.vue';
import Login from '../Client/Login/Login.vue';
import ResetPassword from '../Client/Forget/Forget.vue';
import OTP from '../Client/OTP/OTP.vue';
import { comment } from "postcss";
const routes=[
    {
        path:'/Home',
        name:'Home',
        component:HelloWord
    },
    {
        path:'/HomeAdmin',
        name:'Admin',
        component:HomeAdmin
    },
    {
        path:'/CreateAcc',
        name:'CreateAccount',
        component:CreateAccount
    },
    {
        path:'/Register',
        component:Register
    },{
        path:'/Login',
        component:Login
    },{
        path:'/Forget',
        component:ResetPassword
    },{
        path:'/OTP/:email',
        component:OTP
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes,
    scrollBehavior(to, from, savedPosition) {
        if (savedPosition) {
            return savedPosition;
        } else {
            return { left: 0, top: 0, behavior: 'smooth' };
        }
    }
});
export default router;