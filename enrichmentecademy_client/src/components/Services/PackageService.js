import axios from "axios";
import { Package } from "../api/api";
const baseurl=Package();
export const GetSubject=async()=>{
   const response=await axios.get(`${baseurl}ShowSubject`);
   return response.data;
}
export const AddPackage=async(Package)=>{
   try{
      const response=await fetch(`${baseurl}CreatePackage`,{
         method:'POST',
         headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Package),
      })
      const data = await response.json();
      if (!response.ok) {
          return data;
      }
      return data;   
   }catch(error){
      console.error('Error in AddPackage:', error.message);
      throw error;
   }
}