<template>
    <div>
        <h3>Login page</h3>
        <form>
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
    name: "LoginPage"
}
</script>