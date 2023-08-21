<template>
	<div>
		<AppNavigator />
		<router-view />
	</div>
</template>

<script>
import AppNavigator from './components/Nav/AppNavigator.vue';

export default {
	name: 'App',
	components: {
		AppNavigator,
	}
}
</script>

<style>
</style>
