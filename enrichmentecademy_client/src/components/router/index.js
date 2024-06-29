import { createRouter,createWebHistory } from "vue-router";
import HelloWord from '../Client/Homepage/HomePage.vue';
import HomeAdmin from '../Admin/HomePage/HomePage.vue';
import CreateAccount from '../Admin/Account/CreateAccount.vue';
import Register from '../Client/Register/Register.vue'
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
    }
]
const router=createRouter({
    history:createWebHistory(),
    routes
})
export default router;