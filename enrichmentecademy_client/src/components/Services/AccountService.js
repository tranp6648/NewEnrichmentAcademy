import axios from "axios";
import  { CreateAccount } from '../api/api'
const baseurl=CreateAccount();
export const ShowAccount=async()=>{
const response=await axios.get(`${baseurl}ShowAccountTeacher`);
return response.data;
}