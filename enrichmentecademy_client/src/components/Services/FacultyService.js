import axios from "axios";
import { Faculty } from "../api/api";

const baseurl = Faculty();
export const GetFaculty = async () => {
    const response = await axios.get(`${baseurl}ShowFaculty`);
    return response.data;
}
export const DeleteFaculty = async (Id) => {
    try {
        const response = await fetch(`${baseurl}DeleteFaculty/${Id}`, {
            method: 'Delete',
            headers: {
                'Content-Type': 'application/json',
            },
        })
        const data = await response.json();
        if (!response.ok) {
            return data;
        }
        return data;
    } catch (error) {
        console.error('Error in DeleteFaculty:', error.message);
        throw error;
    }
}
export const UpdateFaculty = async (id, Faculty) => {
    try {
        const response = await fetch(`${baseurl}UpdateFaculty/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(Faculty)
        })
        const data = await response.json();
        if (!response.ok) {
            return data;
        }
        return data;
    } catch (error) {
        console.error('Error in UpdateFaculty:', error.message);
        throw error;
    }
}
export const CreateFaculty = async (Faculty) => {
    try {
        const response = await fetch(`${baseurl}CreateFaculty`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(Faculty),
        })
        const data = await response.json();
        if (!response.ok) {
            return data;
        }
        return data;
    } catch (error) {
        console.error('Error in AddFaculty:', error.message);
        throw error;
    }
}