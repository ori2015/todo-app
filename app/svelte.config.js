import sveltePreprocess from 'svelte-preprocess';

const config = {
  preprocess: sveltePreprocess(),
  kit: {
    // adapter: adapter(), // Uncomment and configure the adapter for deployment
    alias: {
      $components: 'src/lib/components',
    },
  },
};

export default config;