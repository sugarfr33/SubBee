<template>
    <div>
        <h3>Login page</h3>
        <form @submit.prevent="handleLogin">
            <label>Username</label>
            <input type="text" v-model="username" />
            <label>Password</label>
            <input type="password" v-model="password" />
            <button>Login</button>
        </form>
        
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: "LoginPage",
    data() {
        return {
            username: '',
            password: '',
        }
    },

    methods: {
        handleLogin() {
            alert('test')
        },
    },
}
</script>