<template>
    <div>
        <h3>Register page</h3>
        <form @submit.prevent="handleRegister">
            <label>Username</label>
            <input type="text" v-model="username" />
            <label>Password</label>
            <input type="password" v-model="password" />
            <label>Name</label>
            <input type="text" v-model="name" />
            <label>Email</label>
            <input type="email" v-model="email" />
            <button>Save</button>
        </form>
        
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: "RegisterPage",
    data() {
        return {
            username: '',
            password: '',
            name: '',
            email: '',
        }
    },
    methods: {
        async handleRegister() {

            const response = await axios.post('api/auth/registration', {
                username: this.username,
                password: this.password,
                name: this.name,
                email: this.email,
            });
            
            console.log(response);
            this.$router.push('/login')
        }
    }
}
</script>