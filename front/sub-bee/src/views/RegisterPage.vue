<template>
    <div>
        <h3>Register page</h3>
        <form @submit.prevent="handleRegister">
            <label>Username</label>
            <GenericTextbox />
            <label>Password</label>
            <GenericTextboxPassword />
            <GenericSubmitButton>Save</GenericSubmitButton>
        </form>
        
    </div>
</template>

<script>
export default {
    name: "RegisterPage",
    methods: {
        handleRegister() {
            alert('test')
        }
    }
}
</script>