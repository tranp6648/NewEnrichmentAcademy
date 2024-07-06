import axios from "axios";
import { Subject } from "../api/api"

const baseUrl=Subject();
export const ShowFaculty=async()=>{
    const response=await axios.get(`${baseUrl}ShowFaculty`);
    return response.data;
}
export const GetSubject=async()=>{
    const response=await axios.get(`${baseUrl}ShowSubject`);
    return response.data;
}
export const DeleteSubject=async(Id)=>{
    try{
        const response=await fetch(`${baseUrl}DeleteSubject/${Id}`,{
            method:'Delete',
            headers: {
                'Content-Type': 'application/json',
            },
        })
        const data = await response.json();
        if (!response.ok) {
            return data;
        }
        return data;
    }catch(error){
        console.error('Error in DeleteSubject:', error.message);
        throw error;
    }
}
export const UpdateSubject=async(Id,Update)=>{
    try{
        const response=await fetch(`${baseUrl}UpdateSubject/${Id}`,{
            method:'Put',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(Update),
        })
        const data = await response.json();
        if (!response.ok) {
            return data;
        }
        return data;
    }catch(error){
        console.error('Error in DeleteFaculty:', error.message);
        throw error;
    }
}
export const CreateSubject=async(Subject)=>{
    try{
        const response=await fetch(`${baseUrl}AddSubject`,{
            method: 'POST',
            body: Subject
        })
        const data = await response.json();
        if (!response.ok) {
            return data;
        }
        return data;
    }catch(error){
        console.error('Error in DeleteFaculty:', error.message);
        throw error;
    }
}